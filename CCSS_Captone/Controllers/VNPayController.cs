using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : Controller
    {
        private readonly IVNPayService _vNPayService;
        public VNPayController(IVNPayService vNPayService)
        {

            _vNPayService = vNPayService;
        }
        //[HttpPost]
        //public IActionResult CreatePaymentUrlVnpay(VNPayInformationModel     model)
        //{
        //    var url = _vNPayService.CreatePaymentUrl(model, HttpContext);

        //    return Ok(url);
        //}
        //[HttpGet]
        //[Route("PaymentCallBack")]
        //public IActionResult PaymentCallbackVnpay()
        //{
        //    var response = _vNPayService.PaymentExecute(Request.Query);

        //    return Json(response);
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePaymentUrlVnpay(VNPayInformationModel model)
        {
            var url = await _vNPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(url);
        }
        [HttpGet]
        [Route("PaymentCallBack")]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
            var isWeb = HttpContext.Request.Query["platform"].ToString().ToLower() == "web";
            var response = await _vNPayService.VNPayPaymentExecuteAsync(Request.Query);
            
            if (isWeb && response.Equals("Thanh toán thất bại"))
            {
                return Redirect("http://localhost:3000/fail-payment");

            }
            else if (isWeb )
            {
                return Redirect("http://localhost:3000/success-payment");
               
            }

            if (response.Equals("Thanh toán thất bại"))
            {
                return Redirect("ccss://payment-fail");
            }
            return Redirect("ccss://payment-success");
        }

    }
}