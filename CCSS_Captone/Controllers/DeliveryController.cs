using CCSS_Service;
using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService IDeliveryService)
        {
            _deliveryService = IDeliveryService;
        }
        [HttpPost("create-delivery/{orderId}")]
        public async Task<IActionResult> CreateDelivery(string orderId)
        {
            var result = await _deliveryService.CreateDeliveryOrderAsync(orderId);
            return Ok(result);
        }
        [HttpPost("caculate-fee-delivery/{orderId}")]
        public async Task<IActionResult> CaculateDelivery(string orderId)
        {
            var result = await _deliveryService.CalculateDeliveryFeeAsync(orderId);
            return Ok(result);
        }

        [HttpGet("status/{orderCode}")]
        public async Task<IActionResult> GetShippingStatus(string orderCode)
        {
            try
            {
                // Gọi hàm ViewDeliveryStatusAsync từ Service
                var status = await _deliveryService.ViewDeliveryStatuslAsync(orderCode);

                if (status == null)
                {
                    return NotFound(new { message = "Status not found" });
                }

                // Trả về status dưới dạng kết quả
                return Ok(new { status = status });
            }
            catch (Exception ex)
            {
                // Trả về lỗi nếu có lỗi xảy ra
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
        /// <summary>Lấy danh sách tỉnh/thành</summary>
        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _deliveryService.GetProvincesAsync();
            return Ok(result);
        }

        /// <summary>Lấy danh sách quận/huyện theo tỉnh</summary>
        [HttpPost("districts/{provinceId}")]
        public async Task<IActionResult> GetDistricts( int provinceId)
        {
            var result = await _deliveryService.GetDistrictsAsync(provinceId);
            return Ok(result);
        }

        /// <summary>Lấy danh sách phường/xã theo quận</summary>
        [HttpPost("wards/{districtId}")]
        public async Task<IActionResult> GetWards( int districtId)
        {
            var result = await _deliveryService.GetWardsAsync(districtId);
            return Ok(result);
        }
        
        [HttpPost("cancel/{code}")]
        public async Task<IActionResult> CancelDelevery(string code)
        {
            var result = await _deliveryService.CancelOrderAsync(code);
            return Ok(result);
        }
    }
}
