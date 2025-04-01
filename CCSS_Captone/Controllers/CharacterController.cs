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

        //[HttpGet("categoryId/{categoryId}")]
        //public async Task<ActionResult<CategoryResponse>> GetCharactersByCategoryId(string categoryId)
        //{
        //    var characters = await _characterService.GetCharactersByCategoryId(categoryId);
        //    if (characters == null)
        //    {
        //        return NotFound(new { message = "Category not found." });
        //    }
        //    return Ok(characters);
        //}

        [HttpGet]
        public async Task<ActionResult<CharacterResponse>> GetCharacters(string? characterId, string? categoryId, string? characterName, double? MaxHeight, double? MinHeight, double? Maxweight, double? MinWeight, double? MinPrice, double? MaxPrice)
        {
            var character = await _characterService.GetCharacters(characterId, categoryId, characterName, MaxHeight, MinHeight, Maxweight, MinWeight, MinPrice, MaxPrice);
            if (character == null)
            {
                return NotFound(new { message = "Character not found." });
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromForm] CharacterRequest character, [FromForm] List<IFormFile> imageFiles)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterService.AddCharacter(character, imageFiles);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(string id, [FromForm]  CharacterRequest characterRequest, [FromForm] List<string>?characterImageIds, List<IFormFile>? images)
        {
            if (ModelState.IsValid)
            {
                if (images.Count != characterImageIds.Count)
                {
                    return BadRequest("Số lượng ID và số lượng ảnh không khớp.");
                }

                var characterImageRequest = new List<CharacterImageRequest>();
                for (int i = 0; i < images.Count; i++)
                {
                    characterImageRequest.Add(new CharacterImageRequest
                    {
                        CharactetImageId = characterImageIds[i],
                        Image = images[i]
                    });
                }

                var result = await _characterService.UpdateCharacter(id, characterRequest, characterImageRequest);
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
