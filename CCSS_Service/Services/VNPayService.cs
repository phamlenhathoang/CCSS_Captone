using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IVNPayService
    {
        string CreatePaymentUrl(VNPayInformationModel model, HttpContext context);
        //VNPayResponseModel VNPayPaymentExecute(IQueryCollection collections);
        Task<string> VNPayPaymentExecuteAsync(IQueryCollection collection);

    }
    public class VNPayService : IVNPayService
    {
        private readonly IConfiguration _configuration;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventRepository _eventrepository;



        public VNPayService(IConfiguration configuration, IAccountRepository accountRepository, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository, IEventRepository eventrepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
            _ticketAccountService = ticketAccountService;
            _paymentRepository = paymentRepository;
            _eventrepository = eventrepository;
        }
        public string CreatePaymentUrl(VNPayInformationModel model, HttpContext context)
        {
            Console.WriteLine("hihi");
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VNPayLibrary();
            //var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"]
            var urlCallBack = _configuration["Vnpay:PaymentBackReturnUrl"];
            Console.WriteLine(urlCallBack);

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            var extraData = new
            {
                AccountId = model.AccountId,
                TicketId = model.TicketId,
                TicketQuantity = model.TicketQuantity,
                Purpose = model.Purpose.ToString(), // Chuyển enum thành string
                ContractId = model.ContractId, // Thêm ContractId
                CartId = model.CartId
            };

            // Chuyển đối tượng thành chuỗi JSON và mã hóa Base64
            string jsonExtraData = System.Text.Json.JsonSerializer.Serialize(extraData);
            string base64ExtraData = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonExtraData));

            // Thêm thông tin chính
            // Kết hợp OrderInfo với mã hóa thông tin bổ sung
            pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount} {base64ExtraData}");
            //pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount}");
            pay.AddRequestData("vnp_OrderType", model.OrderType);

            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }







        public async Task<string> VNPayPaymentExecuteAsync(IQueryCollection collection)
        {
            var pay = new VNPayLibrary();
            var response = pay.GetFullResponseData(collection, _configuration["Vnpay:HashSecret"]);
            Console.WriteLine("hehe");

            // Kiểm tra từng tham số trong collections để tìm các trường bổ sung
            if (collection.ContainsKey("vnp_OrderInfo"))
            {
                string orderInfo = collection["vnp_OrderInfo"];

                // Phân tích orderInfo để trích xuất thông tin
                string[] parts = orderInfo.Split(' ');
                if (parts.Length >= 4)
                {
                    try
                    {
                        // Giả định phần cuối cùng là thông tin được mã hóa
                        string base64Part = parts[parts.Length - 1];
                        byte[] dataBytes = Convert.FromBase64String(base64Part);
                        string jsonData = System.Text.Encoding.UTF8.GetString(dataBytes);

                        // Phân tích JSON
                        var extraData = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);

                        // Gán vào các trường tương ứng
                        if (extraData.ContainsKey("AccountId"))
                            response.AccountId = extraData["AccountId"];

                        if (extraData.ContainsKey("TicketId"))
                            response.TicketId = extraData["TicketId"];

                        if (extraData.ContainsKey("TicketQuantity"))
                            response.TicketQuantity = extraData["TicketQuantity"];

                        if (extraData.ContainsKey("Purpose"))
                            response.Purpose = extraData["Purpose"];

                        if (extraData.ContainsKey("ContractId"))
                            response.ContractId = extraData["ContractId"];

                        if (extraData.ContainsKey("CartId"))
                            response.CartId = extraData["CartId"];
                        if (collection.ContainsKey("vnp_Amount"))
                            response.Amount = response.Amount = double.Parse(collection["vnp_Amount"]);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing extra data: {ex.Message}");
                    }

                }
            }
            PaymentPurpose? purpose = Enum.TryParse(response.Purpose, out PaymentPurpose parsedPurpose)
    ? parsedPurpose
    : (PaymentPurpose?)null;
            switch (purpose)
            {
                case PaymentPurpose.BuyTicket: // mua vé
                    TicketAccountRequest ticketAccountRequest = new TicketAccountRequest
                    {
                        AccountId = response.AccountId,
                        TicketId = response.TicketId,
                        Quantity = int.Parse(response.TicketQuantity),
                        TotalPrice = response.Amount,
                    };

                    var addTicketResult = await _ticketAccountService.AddTicketAccount(ticketAccountRequest);

                    Payment payment = new Payment
                    {
                        PaymentId = Guid.NewGuid().ToString(),
                        Type = "VNPay",
                        Status = PaymentStatus.Complete,
                        Purpose = PaymentPurpose.BuyTicket,
                        CreatAt = DateTime.UtcNow,
                        TransactionId = response.TransactionId,
                        Amount = response.Amount,
                        TicketAccountId = addTicketResult.TicketAccountId
                    };

                    await _paymentRepository.AddPayment(payment);
                    var account = await _accountRepository.GetAccountByAccountId(response.AccountId);
                    var event1 = await _eventrepository.GetEventByTicketId(response.TicketId);
                    var sendMail = new SendMail();
                    //await sendMail.SendEmailNotification(purpose, account.Email, addTicketResult.TicketCode, event1.EventName, event1.Location, event1.StartDate, addTicketResult.Quantity);
                    return "mua vé thành công";

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng
                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng
                case PaymentPurpose.Order:      // mua hàng
                    return null;

                default:
                    return null;
            }


        }


    }
}