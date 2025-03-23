using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCharacterController : ControllerBase
    {
        private readonly ICustomerCharacterService custromerCharacterService;

        public CustomerCharacterController(ICustomerCharacterService custromerCharacterService)
        {
            this.custromerCharacterService = custromerCharacterService;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddCustromerCharacter(CustomerCharacterRequest customerCharacterRequest)
        {
            var account = await custromerCharacterService.AddCustomerCharacter(customerCharacterRequest);
            return Ok(account);
        }
    }
}
