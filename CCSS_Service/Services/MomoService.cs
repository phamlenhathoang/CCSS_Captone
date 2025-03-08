using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponse> CreatePaymentAsync(OrderInfoModel model);
        Task<string> PaymentExecuteAsync(IQueryCollection collection);
    }

    public class MomoService : IMomoService
    {

        private readonly IOptions<MomoOptionModel> _options;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventRepository _eventrepository;


        public MomoService(IOptions<MomoOptionModel> options, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository, IAccountRepository accountRepository, IEventRepository eventrepository)
        {
            _options = options;
            _ticketAccountService = ticketAccountService;
            _paymentRepository = paymentRepository;
            _accountRepository = accountRepository;
            _eventrepository = eventrepository;
        }
        public async Task<MomoCreatePaymentResponse> CreatePaymentAsync(OrderInfoModel model)
        {
            model.OrderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = "Khách hàng: " + model.FullName + ". Nội dung: " + model.OrderInfo;
            var extraDataObj = new
            {
                Purpose = model.Purpose.ToString(),
                AccountId = model.AccountId,
                TicketId = model.TicketId,
                TicketQuantity = model.TicketQuantity
            };
            string extraData = JsonConvert.SerializeObject(extraDataObj);
            var rawData =
                $"partnerCode={_options.Value.PartnerCode}" +
                $"&accessKey={_options.Value.AccessKey}" +
                $"&requestId={model.OrderId}" +
                $"&amount={model.Amount}" +
                $"&orderId={model.OrderId}" +
                $"&orderInfo={model.OrderInfo}" +
                $"&returnUrl={_options.Value.ReturnUrl}" +
                $"&notifyUrl={_options.Value.NotifyUrl}" +
                $"&extraData={extraData}";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            // Create an object representing the request data
            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.OrderId,
                amount = model.Amount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = model.OrderId,
                extraData = extraData,
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);
            var momoResponse = JsonConvert.DeserializeObject<MomoCreatePaymentResponse>(response.Content);
            return momoResponse;

        }





        public async Task<string> PaymentExecuteAsync(IQueryCollection collection)
        {
            var amountSt = collection["amount"].ToString();
            var orderInfo = collection["orderInfo"].ToString();
            var orderId = collection["orderId"].ToString();
            var extraData = collection["extraData"].ToString();

            // Mặc định giá trị null
            string? accountId = null;
            string? ticketId = null;
            int? ticketQuantity = null;
            double? amount = null;
            PaymentPurpose? purpose = null;

            if (!string.IsNullOrEmpty(extraData))
            {
                try
                {
                    var extraDataObj = JsonConvert.DeserializeObject<dynamic>(extraData);
                    accountId = extraDataObj?.AccountId;
                    ticketId = extraDataObj?.TicketId;

                    // Chuyển đổi ticketQuantity từ string sang int?
                    if (int.TryParse((string?)extraDataObj?.TicketQuantity, out int parsedQuantity))
                    {
                        ticketQuantity = parsedQuantity;
                    }
                    if (double.TryParse(amountSt, out double parsedAmount))
                    {
                        amount = parsedAmount;
                    }
                    // Parse Purpose từ string sang enum
                    if (Enum.TryParse<PaymentPurpose>((string?)extraDataObj?.Purpose, out var parsedPurpose))
                    {
                        purpose = parsedPurpose;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi parse extraData: {ex.Message}");
                }
            }

            
            switch (purpose)
            {
                case PaymentPurpose.BuyTicket: // mua vé
                    TicketAccountRequest ticketAccountRequest = new TicketAccountRequest
                    {
                        AccountId = accountId,
                        TicketId = ticketId,
                        quantitypurchased = ticketQuantity.GetValueOrDefault(),
                        TotalPrice = amount.GetValueOrDefault(),
                    };

                    var addTicketResult = await _ticketAccountService.AddTicketAccount(ticketAccountRequest);

                    Payment payment = new Payment
                    {
                        PaymentId = Guid.NewGuid().ToString(),
                        Type = "Momo",
                        Status = PaymentStatus.Complete,
                        Purpose = PaymentPurpose.BuyTicket,
                        CreatAt = DateTime.UtcNow,
                        TransactionId = orderId,
                        Amount = amount.GetValueOrDefault(),
                        TicketAccountId = addTicketResult.TicketAccountId
                    };

                    await _paymentRepository.AddPayment(payment);
                    var account = await _accountRepository.GetAccountByAccountId(accountId);
                    var event1 = await _eventrepository.GetEventByTicketId(ticketId);
                    await SendEmailNotification(purpose, account.Email, addTicketResult.TicketCode, event1.EventName, event1.Location, event1.StartDate, addTicketResult.quantitypurchased);
                    return "mua vé thành công";

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng
                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng
                case PaymentPurpose.Order:      // mua hàng
                    return null;

                default:
                    return null;
            }

        }

        public async Task<bool> SendEmailNotification(PaymentPurpose? purpose, string toEmail, string ticketCode, string eventName, string location, DateTime startDate, int quantity)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();

                string fromEmail = configuration["FromEmail:Email"];
                string emailPassword = configuration["FromEmail:Password"];

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("CCSS", fromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = purpose switch
                {
                    PaymentPurpose.BuyTicket => "Xác nhận đặt vé thành công",
                    PaymentPurpose.ContractDeposit => "Xác nhận đặt cọc hợp đồng",
                    PaymentPurpose.contractSettlement => "Xác nhận tất toán hợp đồng",
                    PaymentPurpose.Order => "Xác nhận đơn hàng",
                    _ => "Thông báo thanh toán"
                };

                string emailBody = purpose switch
                {
                    PaymentPurpose.BuyTicket => $@"
                <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #5a189a; text-align: center;'>🎉 Chúc mừng, bạn đã đặt vé thành công! 🎉</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>🌟 Sự kiện:</strong> {eventName}</p>
        <p><strong>📍 Địa điểm:</strong> {location}</p>
        <p><strong>🕒 Ngày diễn ra:</strong> {startDate:HH:mm dd/M/yyyy}</p>
        <p><strong>🎟 Mã vé:</strong> <span style='color: #d63384; font-size: 18px;'>{ticketCode}</span></p>
        <p><strong>👥 Số lượng vé:</strong> {quantity}</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px; font-weight: bold'>📢 Vui lòng mang theo mã vé khi tham dự để check-in.</p>
        <p style='margin-top: 15px; ;'>🥰 Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi, hẹn gặp bạn tại sự kiện sắp tới!! 😘</p>
    </div>
</div>",

                    PaymentPurpose.ContractDeposit => $@"
                <h2>Bạn đã đặt cọc hợp đồng thành công!</h2>
                <p>Vui lòng kiểm tra chi tiết hợp đồng trong hệ thống.</p>",

                    PaymentPurpose.contractSettlement => $@"
                <h2>Bạn đã tất toán hợp đồng thành công!</h2>
                <p>Hợp đồng đã hoàn tất. Cảm ơn bạn!</p>",

                    PaymentPurpose.Order => $@"
                <h2>Đơn hàng của bạn đã được xác nhận!</h2>
                <p>Chúng tôi sẽ sớm giao hàng cho bạn.</p>",

                    _ => "<p>Cảm ơn bạn đã thực hiện thanh toán.</p>"
                };

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true; // ✅ Gửi email thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false; // ❌ Gửi email thất bại
            }
        }


        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }

    }
}
