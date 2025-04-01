using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
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
        Task<string> MomoPaymentExecuteAsync(IQueryCollection collection);
    }

    public class MomoService : IMomoService
    {

        private readonly IOptions<MomoOptionModel> _options;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountCouponRepository _accountCouponRepository;
        private readonly IEventRepository _eventrepository;
        private readonly IContractRespository _contractRespository;
        private readonly IContractServices _contractServices;
        private readonly IOrderRepository _orderRepository;

        public MomoService(IContractServices _contractServices, IOptions<MomoOptionModel> options, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository, IAccountRepository accountRepository, IEventRepository eventrepository, IAccountCouponRepository accountCouponRepository, IContractRespository contractRespository, IOrderRepository orderRepository)
        {
            _options = options;
            _ticketAccountService = ticketAccountService;
            _paymentRepository = paymentRepository;
            _accountRepository = accountRepository;
            _eventrepository = eventrepository;
            _accountCouponRepository = accountCouponRepository;
            _contractRespository = contractRespository;
            _orderRepository = orderRepository;
            this._contractServices = _contractServices;
        }
        public async Task<MomoCreatePaymentResponse> CreatePaymentAsync(OrderInfoModel model)
        {
            if (model.AccountCouponId != null)
            {
                var accountCoupon = await _accountCouponRepository.GetAccountCoupon(model.AccountCouponId);
                if (model.Purpose == PaymentPurpose.Order && accountCoupon.Coupon.Type == CouponType.ForContract)
                {
                    return new MomoCreatePaymentResponse { IsSuccess = false, ErrorMessage = "Mã giảm giá không áp dụng cho đơn hàng." };
                }
                else if ((model.Purpose == PaymentPurpose.ContractDeposit || model.Purpose == PaymentPurpose.contractSettlement)
                         && accountCoupon.Coupon.Type == CouponType.ForOrder)
                {
                    return new MomoCreatePaymentResponse { IsSuccess = false, ErrorMessage = "Mã giảm giá không áp dụng cho hợp đồng." };
                }
                else if (accountCoupon.IsActive == false)
                {
                    return new MomoCreatePaymentResponse { IsSuccess = false, ErrorMessage = "Mã giảm giá không khả dụng." };
                }
                else if (model.Purpose == PaymentPurpose.Order && accountCoupon.Coupon.Type == CouponType.ForOrder)
                {
                    model.Amount -= (model.Amount * accountCoupon.Coupon.Percent) / 100;
                }
            }


            model.OrderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = "Khách hàng: " + model.FullName + ". Nội dung: " + model.OrderInfo;
            var extraDataObj = new
            {
                Purpose = model.Purpose.ToString(),
                AccountId = model.AccountId,
                TicketId = model.TicketId,
                TicketQuantity = model.TicketQuantity,
                AccountCoupon = model.AccountCouponId,
                ContractId = model.ContractId,
                OrderPaymentID = model.OrderpaymentId

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


            Payment payment = new Payment
            {
                PaymentId = Guid.NewGuid().ToString(),
                Type = "Momo",
                Status = PaymentStatus.Pending,
                Purpose = model.Purpose,
                CreatAt = DateTime.UtcNow,
                TransactionId = model.OrderId,
                Amount = model.Amount,
                AccountCouponID = model.AccountCouponId
                //TicketAccountId = addTicketResult.TicketAccountId
            };

            await _paymentRepository.AddPayment(payment);
            return momoResponse;



        }

        public async Task<string> MomoPaymentExecuteAsync(IQueryCollection collection)
        {
            var amountSt = collection["amount"].ToString();
            var orderInfo = collection["orderInfo"].ToString();
            var orderId = collection["orderId"].ToString();
            var extraData = collection["extraData"].ToString();

            // Mặc định giá trị null
            string? accountId = null;
            string? ticketId = null;
            string? contractId = null;
            string? OrderPaymentId = null;
            int? ticketQuantity = null;
            double? amount = null;
            string? accountCouponId = null;
            PaymentPurpose? purpose = null;

            if (!string.IsNullOrEmpty(extraData))
            {
                try
                {
                    var extraDataObj = JsonConvert.DeserializeObject<dynamic>(extraData);
                    accountId = extraDataObj?.AccountId;
                    ticketId = extraDataObj?.TicketId;
                    contractId = extraDataObj?.ContractId;
                    OrderPaymentId = extraDataObj?.OrderPaymentID;
                    accountCouponId = extraDataObj?.AccountCoupon;

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
            if (string.IsNullOrEmpty(orderId))
            {
                return "Thiếu orderId!";
            }
            var existingPayment = await _paymentRepository.GetPaymentByTransactionId(orderId);
            if (existingPayment == null)
            {
                return "Không tìm thấy payment để cập nhật!";
            }
            var account = await _accountRepository.GetAccountByAccountId(accountId);
            var sendMail = new SendMail();
            Contract contract = new Contract();
            if (contractId != null)
            {
                 contract = await _contractRespository.GetContractById(contractId);
            }
            existingPayment.Status = PaymentStatus.Complete;
            switch (purpose)
            {
                case PaymentPurpose.BuyTicket: // mua vé
                    TicketAccountRequest ticketAccountRequest = new TicketAccountRequest
                    {
                        AccountId = accountId,
                        TicketId = ticketId,
                        Quantity = ticketQuantity.GetValueOrDefault(),
                        TotalPrice = amount.GetValueOrDefault(),
                    };

                    var addTicketResult = await _ticketAccountService.AddTicketAccount(ticketAccountRequest);

                    //Payment payment = new Payment
                    //{
                    //    PaymentId = Guid.NewGuid().ToString(),
                    //    Type = "Momo",
                    //    Status = PaymentStatus.Complete,
                    //    Purpose = PaymentPurpose.BuyTicket,
                    //    CreatAt = DateTime.UtcNow,
                    //    TransactionId = orderId,
                    //    Amount = amount.GetValueOrDefault(),
                    //    TicketAccountId = addTicketResult.TicketAccountId
                    //};
                   
                    existingPayment.TicketAccountId = addTicketResult.TicketAccountId;

                    await _paymentRepository.UpdatePayment(existingPayment);

                    
                    var event1 = await _eventrepository.GetEventByTicketId(ticketId);
                    
                    
                    
                    await sendMail.SendEmailNotification(purpose, account.Email, addTicketResult.TicketCode, event1.EventName, event1.Location, event1.StartDate, addTicketResult.Quantity, null, null);
                    return "mua vé thành công";

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng
                    
                    existingPayment.ContractId = contractId;
                    await _paymentRepository.UpdatePayment(existingPayment);

                    bool result = await _contractServices.UpdateStatusContract(contractId, "Progressing", null);
                    if (!result)
                    {
                        throw new Exception("Can not update status contract");
                    }
                    
                    await sendMail.SendEmailNotification(purpose, account.Email, null, contract.ContractName, null, DateTime.Now, null, amount, account.Name);

                    return "Đặt cọc thành công ";

                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng

                    
                    existingPayment.ContractId = contractId;
                    await _paymentRepository.UpdatePayment(existingPayment);
                    bool rs = await _contractServices.UpdateStatusContract(contractId, "Completed", amount);
                    if (!rs)
                    {
                        throw new Exception("Can not update status contract");
                    }
                    await sendMail.SendEmailNotification(purpose, account.Email, null, contract.ContractName, null, DateTime.Now, null, amount, account.Name);
                    return "Thanh toán thành công ";

                case PaymentPurpose.Order:      // mua hàng
                    var accountCoupon = await _accountCouponRepository.GetAccountCoupon(accountCouponId);
                    var order = await _orderRepository.GetOrderById(OrderPaymentId);
                    order.OrderStatus= OrderStatus.Completed;
                    accountCoupon.IsActive = false;
                    await _accountCouponRepository.UpdateAccountCoupon(accountCoupon);
                    await _orderRepository.UpdateOrder(order);

                    return "mua hàng thành công";

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
