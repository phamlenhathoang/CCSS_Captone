using AutoMapper;
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
        Task<MomoExecuteResult> MomoPaymentExecuteAsync(IQueryCollection collection);
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
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductServices _cartProductServices;
        private readonly IMapper _mapper;
        private readonly IDeliveryService _deliveryService;

        public MomoService(IContractServices _contractServices, IOptions<MomoOptionModel> options, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository, IAccountRepository accountRepository, IEventRepository eventrepository, IAccountCouponRepository accountCouponRepository, IContractRespository contractRespository, IOrderRepository orderRepository, ICartRepository cartRepository, ICartProductServices cartProductServices, IMapper mapper, IDeliveryService deliveryService)
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
            this._cartRepository = cartRepository;
            this._cartProductServices = cartProductServices;
            this._mapper = mapper;
            _deliveryService = deliveryService;
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


            string orderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = "Khách hàng: " + model.FullName + ". Nội dung: " + model.OrderInfo;
            var extraDataObj = new
            {
                Purpose = model.Purpose.ToString(),
                AccountId = model.AccountId,
                TicketId = model.TicketId,
                TicketQuantity = model.TicketQuantity,
                AccountCoupon = model.AccountCouponId,
                ContractId = model.ContractId,
                OrderPaymentID = model.OrderpaymentId,
                IsWeb = model.isWeb

            };
            string extraData = JsonConvert.SerializeObject(extraDataObj);
            var rawData =
                $"partnerCode={_options.Value.PartnerCode}" +
                $"&accessKey={_options.Value.AccessKey}" +
                $"&requestId={orderId}" +
                $"&amount={model.Amount}" +
                $"&orderId={orderId}" +
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
                orderId = orderId,
                amount = model.Amount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = orderId,
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
                TransactionId = orderId,
                Amount = model.Amount,
                AccountCouponID = model.AccountCouponId
                //TicketAccountId = addTicketResult.TicketAccountId
            };

            await _paymentRepository.AddPayment(payment);
            return momoResponse;



        }

        public async Task<MomoExecuteResult> MomoPaymentExecuteAsync(IQueryCollection collection)
        {
            var amountSt = collection["amount"].ToString();
            var orderInfo = collection["orderInfo"].ToString();
            var orderId = collection["orderId"].ToString();
            var extraData = collection["extraData"].ToString();
            var Resultcode = collection["errorCode"].ToString();
            
            // Mặc định giá trị null
            string? accountId = null;
            int? ticketId = null;
            string? contractId = null;
            string? OrderPaymentId = null;
            int? ticketQuantity = null;
            double? amount = null;
            string? accountCouponId = null;
            bool? isWeb = false;
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
                    if (int.TryParse((string?)extraDataObj?.ticketId, out int parsedTicketId))
                    {
                        ticketId = parsedTicketId;
                    }
                    if (double.TryParse(amountSt, out double parsedAmount))
                    {
                        amount = parsedAmount;
                    }
                    if (bool.TryParse((string?)extraDataObj?.IsWeb, out var parsedIsWeb))
                    {
                        isWeb = parsedIsWeb;
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
            if (Resultcode != "0")
            {
                return new MomoExecuteResult
                {
                    Message = "Thanh toán thất bại",
                    IsWeb = isWeb ?? false
                };
            }
            if (string.IsNullOrEmpty(orderId))
            {
                throw new Exception("Thiếu orderId!");
            }
            var existingPayment = await _paymentRepository.GetPaymentByTransactionId(orderId);
            if (existingPayment == null)
            {
                throw new Exception("Thiếu orderId");
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
                        TicketId = ticketId ?? 0,
                        Quantity = ticketQuantity.GetValueOrDefault(),
                        TotalPrice = amount.GetValueOrDefault(),
                    };

                    var addTicketResult = await _ticketAccountService.AddTicketAccount(ticketAccountRequest);

                   
                   
                    existingPayment.TicketAccountId = addTicketResult.TicketAccountId;

                    await _paymentRepository.UpdatePayment(existingPayment);

                    
                    var event1 = await _eventrepository.GetEventByTicketId(ticketId);
                    
                    
                    
                    await sendMail.SendEmailNotification(purpose, account.Email, addTicketResult.TicketCode, event1.EventName, event1.Location, event1.StartDate, addTicketResult.Quantity, null, null);
                    
                    return new MomoExecuteResult
                    {
                        Message = "mua vé thành công",
                        IsWeb = isWeb ?? false
                    };

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng
                    
                    existingPayment.ContractId = contractId;
                    await _paymentRepository.UpdatePayment(existingPayment);

                    bool result = await _contractServices.UpdateStatusContract(contractId, "Deposited", null);
                    if (!result)
                    {
                        throw new Exception("Can not update status contract");
                    }
                    
                    await sendMail.SendEmailNotification(purpose, account.Email, null, contract.ContractName, null, DateTime.Now, null, amount, account.Name);

                    return new MomoExecuteResult
                    {
                        Message = "Đặt cọc thành công ",
                        IsWeb = isWeb ?? false
                    };

                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng

                    
                    existingPayment.ContractId = contractId;
                    await _paymentRepository.UpdatePayment(existingPayment);
                    bool rs = await _contractServices.UpdateStatusContract(contractId, "FinalSettlement", amount);
                    if (!rs)
                    {
                        throw new Exception("Can not update status contract");
                    }
                    await sendMail.SendEmailNotification(purpose, account.Email, null, contract.ContractName, null, DateTime.Now, null, amount, account.Name);
                    
                    return new MomoExecuteResult
                    {
                        Message = "Thanh toán thành công ",
                        IsWeb = isWeb ?? false
                    };

                case PaymentPurpose.Order:      // mua hàng
                    existingPayment.OrderId = OrderPaymentId;
                    await _paymentRepository.UpdatePayment(existingPayment);
                    if (accountCouponId != null)
                    {
                        var accountCoupon = await _accountCouponRepository.GetAccountCoupon(accountCouponId);
                        accountCoupon.IsActive = false;

                    }
                    var order = await _orderRepository.GetOrderById(OrderPaymentId);
                    order.OrderStatus= OrderStatus.Completed;

                    var products = await _orderRepository.GetProductByOrderId(OrderPaymentId);
                    var cart = await _cartRepository.GetcartByAccount(accountId);
                   
                    var product = _mapper.Map<List<CartProductRequestDTO>>(products);
                    await _cartProductServices.DeleteCartProductAfterPayment(cart.CartId, product);
                    await _orderRepository.UpdateProductQuantitiesAfterPayment(OrderPaymentId);
                    await _orderRepository.UpdateOrder(order);
                    await _deliveryService.CreateDeliveryOrderAsync(order.OrderId);

                    return new MomoExecuteResult
                    {
                        Message = "mua hàng thành công",
                        IsWeb = isWeb ?? false
                    };

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
