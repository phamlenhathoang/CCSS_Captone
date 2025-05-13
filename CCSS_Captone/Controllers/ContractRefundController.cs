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

        [HttpPut]
        public async Task<IActionResult> UpdateContractRefund(string contractRefundId, UpdateContractRefundRequest contractRefundRequest)
        {
            var result = await _contractRefundService.UpdateContractRefund(contractRefundId, contractRefundRequest);
            return Ok(result);
        }

        [HttpGet("{contractId}")]
        public async Task<IActionResult> GetContractRefundByContractId(string contractId)
        {
            var result = await _contractRefundService.GetContractRefundByContractId(contractId);
            return Ok(result);
        }

        [HttpGet("{contractRefundId}")]
        public async Task<IActionResult> GetContractRefundByContractRefundId(string contractRefundId)
        {
            var result = await _contractRefundService.GetContractRefundByContractRefundId(contractRefundId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContractRefund()
        {
            var result = await _contractRefundService.GetAllContractRefund();
            return Ok(result);
        }
    }
}
