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
        [HttpPost]
        public IActionResult CreatePaymentUrlVnpay(VNPayInformationModel model)
        {
            var url = _vNPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(new { PaymentUrl = url });
        }
        [HttpGet]
        [Route("PaymentCallBack")]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
            var response = await _vNPayService.VNPayPaymentExecuteAsync(Request.Query);

            return Ok(response);
        }

    }
}
