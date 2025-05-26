using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractServices _services;

        public ContractController(IContractServices services)
        {
            _services = services;
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("searchTerm")]
        public async Task<IActionResult> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContract(contractName, contractStatus, startDate, endDate, accountId, contractId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContract()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContract(null, null, null, null, null, null);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetContractByRequestCharacterId")]
        public async Task<IActionResult> GetContractByRequestCharacterId(string requestCharacterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContractByRequestCharacterId(requestCharacterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("contractId/{contractId}")]
        public async Task<IActionResult> GetContractById(string contractId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContractById(contractId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("accountId/{accountId}")]
        public async Task<IActionResult> GetContractByAccountId(string accountId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContractByAccountId(accountId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetRequestInContract/{accountId}")]
        public async Task<IActionResult> GetRequestInContractByAccountId(string accountId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetRequestInContractByAccountId(accountId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Consultant")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> AddContract(string requestId, int deposit)
        {
            var result = await _services.AddContract(requestId, deposit);
            return Ok(result);
        }

        [Authorize(Roles = "Consultant")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> UpdateStatusContract(string contracId, string status, string? reason)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateStatusContract(contracId, status, null, reason);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        
        [HttpPut("UpdateDeliveryContract")]
        public async Task<IActionResult> UpdateDeliveryContract(DeliveryContractRequest deliveryContractRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateDeliveryContract(deliveryContractRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        //[HttpPut("Status")]
        //public async Task<IActionResult> UpdateStatusContract(string contractId, ContractStatus contractStatus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _services.UpdateStatusContract(contractId, contractStatus);
        //        return Ok(result);
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteContract(string contractId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _services.DeleteContract(contractId);
        //    return Ok(result);
        //}
    }
}
