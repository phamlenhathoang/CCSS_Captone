using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractCharacterController : ControllerBase
    {
        private readonly IContractCharacterService contractCharacterService;

        public ContractCharacterController(IContractCharacterService contractCharacterService)
        {
            this.contractCharacterService = contractCharacterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContractCharactersByContractId(string contractId)
        {
            var contractCharacters = await contractCharacterService.GetContractCharactersByContractId(contractId);
            return Ok(contractCharacters);
        }
    }
}
