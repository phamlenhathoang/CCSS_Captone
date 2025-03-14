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

        public async Task<IActionResult> CreateRequest(RequestDtos requestDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.AddRequest(requestDtos);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
