using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("GetAllCoupon")]
        public async Task<IActionResult> GetAllCoupon(string? searchterm)
        {
            if (ModelState.IsValid)
            {
                var result = await _couponService.GetAllCoupon(searchterm);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetCouponById")]
        public async Task<IActionResult> GetCouponById(string couponId)
        {
            if (ModelState.IsValid)
            {
                var result = await _couponService.GetCouponById(couponId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponRequest couponRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _couponService.AddCoupon(couponRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([Required] string couponId, [FromBody] CouponRequest couponRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _couponService.UpdateCoupon(couponId, couponRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(string couponId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _couponService.DeleteCoupon(couponId);
            return Ok(result);
        }
    }
}
