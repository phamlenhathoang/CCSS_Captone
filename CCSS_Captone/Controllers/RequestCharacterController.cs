using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestCharacterController : ControllerBase
    {
        private readonly IRequestCharacterService _characterServices;

        public RequestCharacterController(IRequestCharacterService characterServices)
        {
            _characterServices = characterServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestCharacterId(string requestId,string characterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.GetRequestCharacter(requestId,characterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
