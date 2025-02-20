using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService) 
        {
            _packageService = packageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponse>> GetPackage(string id)
        {
            var character = await _packageService.GetPackage(id);
            if (character == null)
            {
                return NotFound(new { message = "Package not found." });
            }
            return Ok(character);
        }

        [HttpGet]
        public async Task<ActionResult<PackageResponse>> GetAll()
        {
            var character = await _packageService.GetAll();
            if (character == null)
            {
                return NotFound(new { message = "Package not found." });
            }
            return Ok(character);
        }
    }
}
