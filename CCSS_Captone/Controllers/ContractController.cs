using AutoMapper;
using CCSS_Service.Models.Request;
using CCSS_Service.Models.Response;
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

        public ContractController(IContractServices services, IMapper mapper)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchterm)
        {
            if (ModelState.IsValid)
            {
                var results = await _services.GetAll(searchterm);
                return Ok(results);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddContract(ContractResponse contractResponse)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddContract(contractResponse);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetContractbyId(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContract(string contractId, ContractRequest contractRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _services.UpdateContract(contractId, contractRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContract(string contractId)
        {
            if (ModelState.IsValid)
            {
                await _services.DeleteContract(contractId);
                return Ok("Delete Contract Success");
            }
            return BadRequest(ModelState);
        }

    }
}
