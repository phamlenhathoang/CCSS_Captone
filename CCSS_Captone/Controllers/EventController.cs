using CCSS_Service.Services;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Lấy danh sách tất cả sự kiện có thể tìm kiếm theo tên
        /// </summary>
        [SwaggerOperation(Description = "role: Mamager, Customer")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Manager, Customer")]
        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents([FromQuery] string? searchTerm)
        {
            try
            {
                // Gọi service để lấy dữ liệu, nếu searchTerm rỗng thì lấy tất cả sự kiện
                var events = await _eventService.GetAllEvents(string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm);

                if (events == null || events.Count == 0)
                {
                    return NotFound("No events found.");
                }

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        /// <summary>
        /// Lấy thông tin chi tiết của một sự kiện theo ID
        /// </summary>
        [HttpGet("GetEvent/{id}")]
        public async Task<IActionResult> GetEvent(string id)
        {
            try
            {
                var eventResponse = await _eventService.GetEvent(id);
                if (eventResponse == null)
                    return NotFound("Event not found");

                return Ok(eventResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo một sự kiện mới
        /// </summary>
        [SwaggerOperation(Description = "role: Mamager")]
        [Authorize(Roles = "Manager")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent([FromBody] CreateEventRequest eventRequest)
        {
            if (eventRequest == null)
                return BadRequest("Invalid request: Event data is null");

            try
            {
                var result = await _eventService.AddEvent(eventRequest);
                if (result.Contains("Success"))
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin sự kiện
        /// </summary>
         [SwaggerOperation(Description = "role: Mamager")]
        [Authorize(Roles = "Manager")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("UpdateEvent/{eventId}")]
        public async Task<IActionResult> UpdateEvent(string eventId, [FromBody] UpdateEventRequest eventRequest)
        {
            if (eventRequest == null)
                return BadRequest("Invalid request: Event data is null");

            try
            {
                var result = await _eventService.UpdateEvent(eventId, eventRequest);
                if (result.Contains("Success"))
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa một sự kiện theo ID
        /// </summary>
        [SwaggerOperation(Description = "role: Mamager")]
        [Authorize(Roles = "Manager")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            try
            {
                var isDeleted = await _eventService.DeleteEvent(id);
                if (!isDeleted)
                    return NotFound("Event not found or could not be deleted");

                return Ok("Delete Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
