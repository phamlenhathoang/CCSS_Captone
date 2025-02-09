using AutoMapper;
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
                await _services.AddContract(contractResponse);
                return Ok("Create Contract Success");
            }
            return BadRequest(ModelState);
        }

        //[HttpGet("{id}")]

    }
}
