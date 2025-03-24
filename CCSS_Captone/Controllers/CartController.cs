using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _services;

        public CartController(ICartServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetCartById(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetCartby{accountId}")]
        public async Task<IActionResult> GetCartByAccountId(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _services.GetCartByAccount(accountId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CartRequest cartRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddCart(cartRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
