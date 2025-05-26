using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Humanizer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize(Roles = "Customer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateRentCostume")]
        public async Task<IActionResult> CreateRentCostumeRequest([FromBody] RequestDtos requestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddRequestRentCostume(requestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        //[Authorize(Roles = "Customer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        //[Authorize(Roles = "Customer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateCreateEvent")]
        public async Task<IActionResult> CreateCreateEventRequest([FromBody] RequestCreateEvent requestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddRequestCreateEvent(requestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        //[Authorize(Roles = "Customer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        //[Authorize(Roles = "Customer, Manager")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Status")]
        public async Task<IActionResult> UpdateStatusRequest(string requestId, RequestStatus requestStatus, string? reason)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.UpdateStatusRequest(requestId, requestStatus, reason);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(string requestId, string? reason)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _services.DeleteRequest(requestId, reason);
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

        //[Authorize(Roles = "Customer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("UpdateDepositRequest")]
        public async Task<IActionResult> UpdateDeposit(string requestId,[FromBody] UpdateDepositDtos dtos)
        {
            if (string.IsNullOrEmpty(dtos.Deposit))
            {
                return BadRequest("Deposit value is required.");
            }
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateDepositRequest(requestId, dtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
