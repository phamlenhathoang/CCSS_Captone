using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterImageController : ControllerBase
    {
        private readonly ICharacterImageServices _services;

        public CharacterImageController(ICharacterImageServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImagebyCharacterId([Required] string characterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetListCharacterImages(characterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddListImageCharacter([Required]string characterId, [FromForm] IFormFileCollection formFiles)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddCharacterImage(characterId, formFiles);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
