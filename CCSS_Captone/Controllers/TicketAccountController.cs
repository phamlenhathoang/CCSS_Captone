using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCSS_Service.Services;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAccountController : ControllerBase
    {
        private readonly ITicketAccountService _ticketAccountService;

        public TicketAccountController(ITicketAccountService ticketAccountService)
        {
            _ticketAccountService = ticketAccountService;
        }

        /// <summary>
        /// Lấy tất cả TicketAccounts (Chỉ lấy nếu Event đang hoạt động - IsActive = true)
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTicketAccounts()
        {
            try
            {
                var ticketAccounts = await _ticketAccountService.GetAllTicketAccounts();
                return Ok(ticketAccounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một TicketAccount theo ID
        /// </summary>
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetTicketAccount(string id)
        {
            try
            {
                var ticketAccount = await _ticketAccountService.GetTicketAccount(id);
                if (ticketAccount == null)
                {
                    return NotFound("TicketAccount not found");
                }
                return Ok(ticketAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm mới một TicketAccount (Vé sẽ giảm đi số lượng đã mua)
        /// </summary>
        [HttpPost("Add")]
        public async Task<IActionResult> AddTicketAccount([FromBody] TicketAccountRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            try
            {
                var result = await _ticketAccountService.AddTicketAccount(request);
                if (result.Contains("Success"))
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin TicketAccount
        /// </summary>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTicketAccount(string id, [FromBody] TicketAccountRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            try
            {
                var result = await _ticketAccountService.UpdateTicketAccount(id, request);
                if (result.Contains("Success"))
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa một TicketAccount theo ID
        /// </summary>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTicketAccount(string id)
        {
            try
            {
                var result = await _ticketAccountService.DeleteTicketAccount(id);
                if (result)
                {
                    return Ok("Delete Success");
                }
                return NotFound("TicketAccount not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
