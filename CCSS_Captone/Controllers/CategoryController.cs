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
            var category = await _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryResponse>> GetAll()
        {
            var category = await _categoryService.GetAll();
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }
            return Ok(category);
        }
    }
}
