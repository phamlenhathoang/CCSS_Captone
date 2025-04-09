using AutoMapper;
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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = CCSS_Repository.Entities.Contract;

namespace CCSS_Service.Services
{
    public interface IVNPayService
    {
        //string CreatePaymentUrl(VNPayInformationModel model, HttpContext context);
        Task<string> CreatePaymentUrl(VNPayInformationModel model, HttpContext context);
        //VNPayResponseModel VNPayPaymentExecute(IQueryCollection collections);
        Task<string> VNPayPaymentExecuteAsync(IQueryCollection collection);
        //string CreatePaymentUrl(VNPayInformationModel model, HttpContext context);
        //VNPayResponseModel PaymentExecute(IQueryCollection collections);


    }
    public class VNPayService : IVNPayService
    {
        private readonly IConfiguration _configuration;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventRepository _eventrepository;
        private readonly IAccountCouponRepository _accountCouponRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductServices _cartProductServices;
        private readonly IMapper _mapper;
        private readonly IContractServices _contractServices;
        private readonly IContractRespository contractRespository;


        public VNPayService(IConfiguration configuration, IAccountRepository accountRepository, ITicketAccountService ticketAccountService, IPaymentRepository paymentRepository, IEventRepository eventrepository, IAccountCouponRepository accountCouponRepository, IOrderRepository orderRepository, ICartRepository cartRepository, ICartProductServices cartProductServices, IMapper mapper, IContractServices contractServices, IContractRespository contractRespository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
            _ticketAccountService = ticketAccountService;
            _paymentRepository = paymentRepository;
            _eventrepository = eventrepository;
            _accountCouponRepository = accountCouponRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _cartProductServices = cartProductServices;
            _mapper = mapper;
            _contractServices = contractServices;
            this.contractRespository = contractRespository;
        }


        public async Task<string> CreatePaymentUrl(VNPayInformationModel model, HttpContext context)
        {
            if (model.AccountCouponId != null)
            {
                var accountCoupon = await _accountCouponRepository.GetAccountCoupon(model.AccountCouponId);
                if (model.Purpose == PaymentPurpose.Order && accountCoupon.Coupon.Type == CouponType.ForContract)
                {
                    return  "Mã giảm giá không áp dụng cho đơn hàng." ;
                }
                else if ((model.Purpose == PaymentPurpose.ContractDeposit || model.Purpose == PaymentPurpose.contractSettlement)
                         && accountCoupon.Coupon.Type == CouponType.ForOrder)
                {
                    return  "Mã giảm giá không áp dụng cho hợp đồng." ;
                }
                else if (accountCoupon.IsActive == false)
                {
                    return "Mã giảm giá không khả dụng." ;
                }
                else if (model.Purpose == PaymentPurpose.Order && accountCoupon.Coupon.Type == CouponType.ForOrder)
                {
                    model.Amount -= (model.Amount * accountCoupon.Coupon.Percent) / 100;
                }
            }
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
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid().ToString(),
                Type = "VNPay",
                Status = PaymentStatus.Pending,
                Purpose = model.Purpose,
                CreatAt = DateTime.UtcNow,
                Amount = model.Amount,
                ContractId = model.ContractId ?? null,
                OrderId = model.OrderPaymentId ?? null
            };
            var extraData = new
            {
                AccountId = model.AccountId,
                TicketId = model.TicketId,
                TicketQuantity = model.TicketQuantity,
                Purpose = model.Purpose.ToString(), 
                //ContractId = model.ContractId, 
                AccountCouponId = model.AccountCouponId, 
                //OrderPaymentId = model.OrderPaymentId,
                //CartId = model.CartId,
                PaymentId = payment.PaymentId
            };

            // Chuyển đối tượng thành chuỗi JSON và mã hóa Base64
            string jsonExtraData = System.Text.Json.JsonSerializer.Serialize(extraData);
            string base64ExtraData = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonExtraData));
            //pay.AddRequestData("vnp_AddInfo", base64ExtraData);

            pay.AddRequestData("vnp_OrderInfo", $" {base64ExtraData}");
            //pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount} {base64ExtraData}");
            //pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount}");

            pay.AddRequestData("vnp_OrderType", model.Purpose.ToString());

            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);
            await _paymentRepository.AddPayment(payment);
            return paymentUrl;
        }







        public async Task<string> VNPayPaymentExecuteAsync(IQueryCollection collection)
        {
            var pay = new VNPayLibrary();
            var response = pay.GetFullResponseData(collection, _configuration["Vnpay:HashSecret"]);


            

            //var Purpose = collection["vnp_OrderType"];
                // Làm việc với purpose
            
            // Kiểm tra từng tham số trong collections để tìm các trường bổ sung
            if (collection.ContainsKey("vnp_OrderInfo"))
            {
                string orderInfo = collection["vnp_OrderInfo"];

                try
                {
                    // Giải mã Base64
                    byte[] dataBytes = Convert.FromBase64String(orderInfo);
                    string jsonData = System.Text.Encoding.UTF8.GetString(dataBytes);

                    // Phân tích JSON
                    var extraData = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);

                    // Gán vào các trường tương ứng
                    if (extraData.ContainsKey("AccountId"))
                        response.AccountId = extraData["AccountId"];

                    if (extraData.ContainsKey("TicketQuantity"))
                        response.TicketQuantity = extraData["TicketQuantity"];

                    if (extraData.ContainsKey("Purpose"))
                        response.Purpose = extraData["Purpose"];

                    if (extraData.ContainsKey("TicketId") && !string.IsNullOrEmpty(extraData["TicketId"]))
                    {
                        response.TicketId = int.Parse(extraData["TicketId"]);
                    }


                    if (extraData.ContainsKey("PaymentId"))
                        response.PaymentId = extraData["PaymentId"];

                    if (collection.ContainsKey("vnp_Amount"))
                        response.Amount = double.Parse(collection["vnp_Amount"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing extra data: {ex.Message}");
                }
            }

    //        PaymentPurpose? purpose = Enum.TryParse(response.Purpose, out PaymentPurpose parsedPurpose)
    //? parsedPurpose
    //: (PaymentPurpose?)null;
            var existingPayment = await _paymentRepository.GetPayment(response.PaymentId);
            if (existingPayment == null)
            {
                throw new Exception("Không tìm thấy payment để cập nhật!");
            }
            //};
            existingPayment.Status = PaymentStatus.Complete;
            existingPayment.TransactionId = response.TransactionId;
            PaymentPurpose purpose = (PaymentPurpose)Enum.Parse(typeof(PaymentPurpose), response.Purpose);
            var sendMail = new SendMail();
            switch (purpose)
            {
                case PaymentPurpose.BuyTicket: // mua vé
                    TicketAccountRequest ticketAccountRequest = new TicketAccountRequest
                    {
                        AccountId = response.AccountId,
                        TicketId = response.TicketId ?? 0,
                        Quantity = int.Parse(response.TicketQuantity),
                        TotalPrice = response.Amount,
                    };

                    var addTicketResult = await _ticketAccountService.AddTicketAccount(ticketAccountRequest);

                    
                    
                    existingPayment.TicketAccountId = addTicketResult.TicketAccountId;

                    await _paymentRepository.UpdatePayment(existingPayment);
                    var account = await _accountRepository.GetAccountByAccountId(response.AccountId);
                    var event1 = await _eventrepository.GetEventByTicketId(response.TicketId);
                    
                    await sendMail.SendEmailNotification(purpose, account.Email, addTicketResult.TicketCode, event1.EventName, event1.Location, event1.StartDate, addTicketResult.Quantity, null, null);
                    return "mua vé thành công";

                case PaymentPurpose.ContractDeposit: // đặt cọc hợp đồng


                    Contract contract = await contractRespository.GetContractById(existingPayment.ContractId);
                    var customer = await _accountRepository.GetAccountByAccountId(response.AccountId);
                    bool result = await _contractServices.UpdateStatusContract(contract.ContractId, "Progressing", null);
                    if (!result)
                    {
                        throw new Exception("Can not update status contract");
                    }

                    await sendMail.SendEmailNotification(purpose, customer.Email, null, contract.ContractName, null, DateTime.Now, null, response.Amount, customer.Name);
                    return "Đặt cọc thành công ";

                case PaymentPurpose.contractSettlement:  // tất toán hợp đồng

                    Contract contract1 = await contractRespository.GetContractById(existingPayment.ContractId);
                    var customer1 = await _accountRepository.GetAccountByAccountId(response.AccountId);
                    bool rs = await _contractServices.UpdateStatusContract(contract1.ContractId, "Completed", response.Amount);
                    if (!rs)
                    {
                        throw new Exception("Can not update status contract");
                    }
                    await sendMail.SendEmailNotification(purpose, customer1.Email, null, contract1.ContractName, null, DateTime.Now, null, response.Amount, customer1.Name);
                    return "Thanh toán thành công ";

                case PaymentPurpose.Order:      // mua hàng
                    
                    if (response.AccountCouponId != null)
                    {
                        var accountCoupon = await _accountCouponRepository.GetAccountCoupon(response.AccountCouponId);
                        accountCoupon.IsActive = false;

                    }
                    var order = await _orderRepository.GetOrderById(existingPayment.OrderId);
                    order.OrderStatus = OrderStatus.Completed;

                    var products = await _orderRepository.GetProductByOrderId(existingPayment.OrderId);
                    var cart = await _cartRepository.GetcartByAccount(response.AccountId);

                    var product = _mapper.Map<List<CartProductRequestDTO>>(products);
                    await _cartProductServices.DeleteCartProductAfterPayment(cart.CartId, product);
                    await _orderRepository.UpdateProductQuantitiesAfterPayment(existingPayment.OrderId);

                    await _orderRepository.UpdateOrder(order);

                    return "mua hàng thành công";


                default:
                    return null;
            }


        }


    }
}