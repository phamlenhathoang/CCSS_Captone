using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharater(string id)
        {
            var character = await _characterService.GetCharacter(id);
            if (character == null)
            {
                return NotFound(new { message = "Character not found." });
            }
            return Ok(character);
        }

        [HttpGet]
        public async Task<ActionResult<CharacterResponse>> GetAll()
        {
            var character = await _characterService.GetAll();
            if (character == null)
            {
                return NotFound(new { message = "Character not found." });
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter(CharacterResponse character)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterService.AddCharacter(character);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(string id, CharacterRequest character)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterService.UpdateCharacter(id, character);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCharacter(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterService.DeleteCharacter(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
