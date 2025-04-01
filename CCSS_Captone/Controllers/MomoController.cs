using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomoController : Controller
    {
        private readonly IMomoService _momoService;

        public MomoController(IMomoService momoService)
        {
            _momoService = momoService;
        }
        //[Authorize(Roles = "Customer")]
        [HttpPost]
        [SwaggerOperation(Description = "purpose==0 (Mua vé)<br>" +
                                "purpose==1 (Trả tiền cọc hợp đồng)<br>" +
                                "purpose==2 (Tất toán hợp đồng)<br>" +
                                "purpose==3 (Mua hàng)")]

        public async Task<IActionResult> CreatePaymentUrl(OrderInfoModel model)
        {
            var response = await _momoService.CreatePaymentAsync(model);
            if (response.IsSuccess == false)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response.PayUrl);
        }
        [SwaggerOperation(Description = "role: không call cái này")]
        [HttpGet]
        [Route("PaymentCallBack")]
        public async Task<IActionResult> PaymentCallBack()
        {
            var response = await _momoService.MomoPaymentExecuteAsync(HttpContext.Request.Query);
            return Redirect("http://localhost:3000/success-payment");
        }
    }
}
