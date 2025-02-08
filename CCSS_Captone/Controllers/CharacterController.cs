using CCSS_Service.Services;
using CCSS_Repository.Entities;
using CCSS_Service.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCSS_Service.Models.Request;

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

        /// <summary>
        /// Lấy danh sách tất cả nhân vật.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        /// <summary>
        /// Lấy thông tin một nhân vật theo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacterById(string id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound(new { message = "Character not found." });
            }
            return Ok(character);
        }

        /// <summary>
        /// Thêm một nhân vật mới.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddCharacter([FromBody] CharacterRequest character)
        {
            if (character == null)
            {
                return BadRequest(new { message = "Invalid character data." });
            }

            bool result = await _characterService.AddCharacterAsync(character);
            if (result)
            {
                return CreatedAtAction(nameof(GetCharacterById), new { id = Guid.NewGuid().ToString() }, character);
            }

            return BadRequest(new { message = "Failed to add character." });
        }

        /// <summary>
        /// Cập nhật thông tin một nhân vật.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(string id, [FromBody] CharacterRequest character)
        {
            if (character == null )
            {
                return BadRequest(new { message = "Invalid character data or ID mismatch." });
            }

            bool result = await _characterService.UpdateCharacterAsync(id, character);
            if (result)
            {
                return NoContent(); // HTTP 204 - Thành công nhưng không trả về dữ liệu
            }

            return NotFound(new { message = "Character not found or update failed." });
        }

        /// <summary>
        /// Xóa một nhân vật theo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(string id)
        {
            bool result = await _characterService.DeleteCharacterAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Character not found or deletion failed." });
        }
    }
}
