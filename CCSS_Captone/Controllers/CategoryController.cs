using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCharater(string id)
        {
            var character = await _categoryService.GetCategory(id);
            if (character == null)
            {
                return NotFound(new { message = "Category not found." });
            }
            return Ok(character);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryResponse>> GetAll()
        {
            var character = await _categoryService.GetAll();
            if (character == null)
            {
                return NotFound(new { message = "Category not found." });
            }
            return Ok(character);
        }
    }
}
