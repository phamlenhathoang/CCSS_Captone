using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceServices _services;
        public ServiceController(IServiceServices services)
        {
            _services = services;
        }

        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetAllServices();
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById(string serviceId)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.GetServiceById(serviceId);
                return Ok(result);  
            }
            return BadRequest(ModelState);
        }
    }
}
