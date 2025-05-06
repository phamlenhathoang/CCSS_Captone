using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractRefundController : ControllerBase
    {
        private readonly IContractRefundService _contractRefundService;

        public ContractRefundController(IContractRefundService contractRefundService)
        {
            _contractRefundService = contractRefundService;
        }

        [HttpPost]
        public async Task<IActionResult> AddContractRefund(ContractRefundRequest contractRefundRequest)
        {
            var result = await _contractRefundService.AddContractRefund(contractRefundRequest);
            return Ok(result);
        }
    }
}
