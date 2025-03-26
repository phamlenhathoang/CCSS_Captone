using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageServices _services;

        public ProductImageController(IProductImageServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImage()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllProductImages();
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddImageProduct(string productId, IFormFileCollection formFiles)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddListImageProduct(productId, formFiles);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateImageProduct(string id, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateProductImage(id, formFile);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
