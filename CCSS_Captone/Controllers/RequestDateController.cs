using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDateController : ControllerBase
    {
        private readonly IRequestDateServices _services;

        public RequestDateController(IRequestDateServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestDateById(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetRequestDate(id);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("CalculateTotalHours")]
        public async Task<IActionResult> CalculateTotalHours(string requestcharacterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.CaculateTotalHour(requestcharacterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ListRequestDateByRequestChracter")]
        public async Task<IActionResult> GetListRequestDateByRequestChracterId(string requestCharacterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetListRequestDateByRequestCharacterId(requestCharacterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ListRequestDateByRequestDate")]
        public async Task<IActionResult> CalculateTotalHoursInRequestDate(string requestDateId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.CaculateTotalHourInRequestDate(requestDateId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
