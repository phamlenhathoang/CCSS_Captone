using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct(string? searchterm)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllProduct(searchterm);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductbyId(string productId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetProductById(productId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductRequest productRequest, [FromForm] List<IFormFile> formFiles)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddProduct(productRequest, formFiles);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string productId, UpdateProductRequest productRequest)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _services.UpdateProduct(productId, productRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _services.DeleteProduct(productId);
            return Ok(result);
        }
    }
}
