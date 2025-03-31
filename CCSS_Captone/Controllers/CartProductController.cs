using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ICartProductServices _services;

        public CartProductController(ICartProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartPoruct()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllCartProduct();
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetListCartProductByCart(string cartId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetListProductInCart(cartId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }


        [HttpGet("GetCartByCartProduct")]
        public async Task<IActionResult> GetCartByProductAndCart(string  cartId, string productId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetCartProduct(cartId, productId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartProduct(string cartId, List<CartProductRequest> cartProductRequests)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddCartProduct(cartId, cartProductRequests);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCartProduct(string cartId, List<CartPorductRequestDtos> cartPorductRequestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.DeleteCartProduct(cartId, cartPorductRequestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartProduct(string cartId, List<UpdateCartProductRequest> updateCartProductRequests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _services.UpdateCartProduct(cartId, updateCartProductRequests);
            return Ok(result);
        }
    }
}
