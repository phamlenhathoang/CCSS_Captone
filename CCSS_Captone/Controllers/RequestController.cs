using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _services;

        public RequestController(IRequestServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequest()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllRequest();
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAllRequestByAccount")]
        public async Task<IActionResult> GetAllRequestByAccount(string accountId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllRequestByAccountId(accountId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetRequestById(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] RequestDtos requestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddRequest(requestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("CreateRentCosplayer")]
        public async Task<IActionResult> CreateRentCosplayerRequest([FromBody] RequestRentCosplayer requestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddRequestRentCosplayer(requestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequest([FromQuery] string RequestId, [FromBody] UpdateRequestDtos updateRequestDtos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.UpdateRequest(RequestId, updateRequestDtos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Status")]
        public async Task<IActionResult> UpdateStatusRequest(string requestId, RequestStatus requestStatus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.UpdateStatusRequest(requestId, requestStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(string requestId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.DeleteRequest(requestId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("totalPrice")]
        public async Task<IActionResult> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices, string serviceId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.TotalPriceRequest(packagePrice, accountCouponPrice, startDate, endDate, requestTotalPrices, serviceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("checkRequest")]
        public async Task<IActionResult> CheckRequest(string requestId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.CheckRequest(requestId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
