using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractServices _services;

        public ContractController(IContractServices services )
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContract(string? searchterm)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllContract(searchterm);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContract(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddContract(ContractRequest contractRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddContract(contractRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContract (string contracId, ContractResponse contractResponse)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateContract(contracId, contractResponse);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContract(string contractId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _services.DeleteContract(contractId);
            return Ok("Delete Success");
        }
    }
}
