using CCSS_Repository.Entities;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayment()
        {
            var account = await paymentService.GetAllPayment();
            return Ok(account);
        }

        [HttpGet("GetAllPaymentByContractId")]
        public async Task<IActionResult> GetAllPaymentByContractId(string contractId)
        {
            var account = await paymentService.GetAllPaymentByContractId(contractId);
            return Ok(account);
        }

        [HttpGet("GetPaymentByPaymentId")]
        public async Task<IActionResult> GetPaymentByPaymentId(string paymentId)
        {
            var account = await paymentService.GetPaymentByPaymentId(paymentId);
            return Ok(account);
        }

        [HttpGet("GetAllPaymentByAccountIdAndPurpose")]
        public async Task<IActionResult> GetAllPaymentByAccountIdAndPurpose(string accountId, PaymentPurpose purpose)
        {
            var account = await paymentService.GetAllPaymentByAccountIdAndPurpose(accountId, purpose);
            return Ok(account);
        }
    }
}
