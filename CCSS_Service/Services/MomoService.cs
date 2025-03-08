using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
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
        public MomoService(IOptions<MomoOptionModel> options, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository)
        {
            _options = options;
            _ticketAccountService = ticketAccountService;
            _paymentRepository = paymentRepository;
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

            //if (purpose == (PaymentPurpose).0) // mua vé
            //{
            //    TicketAccountRequest ticketAccountRequest = new TicketAccountRequest();
            //    ticketAccountRequest.AccountId = accountId;
            //    ticketAccountRequest.TicketId = ticketId;
            //    ticketAccountRequest.quantitypurchased = ticketQuantity.GetValueOrDefault();
            //    ticketAccountRequest.TotalPrice = amount.GetValueOrDefault();

            //    var addTicketResult =  await _ticketAccountService.AddTicketAccount(ticketAccountRequest);


            //    Payment payment = new Payment();
            //    payment.PaymentId = Guid.NewGuid().ToString();
            //    payment.Type = "Momo";
            //    payment.Status = PaymentStatus.Complete;
            //    payment.Purpose = PaymentPurpose.BuyTicket;
            //    payment.TransactionId = orderId;
            //    payment.Amount = amount.GetValueOrDefault();
            //    payment.TicketAccountId = addTicketResult.TicketAccountId;

            //    await _paymentRepository.AddPayment(payment);


            //    return "mua vé thành công";

            //}
            //else if (purpose == (PaymentPurpose).1) // đặt cọc hợp đồng
            //{
            //    return null;
            //}
            //else if (purpose == (PaymentPurpose).2) // tất toán hợp đồng
            //{
            //    return null;
            //}
            //else if(purpose == (PaymentPurpose).3) // mua hàng 
            //{
            //    return null;
            //}
            //else
            //{
            //    return null;
            //}
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

                    return "mua vé thành công";

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng
                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng
                case PaymentPurpose.Order:      // mua hàng
                    return null;

                default:
                    return null;
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
