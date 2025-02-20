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
            var package = await _packageService.GetPackage(id);
            if (package == null)
            {
                return NotFound(new { message = "Package not found." });
            }
            return Ok(package);
        }

        [HttpGet]
        public async Task<ActionResult<PackageResponse>> GetAll()
        {
            var package = await _packageService.GetAll();
            if (package == null)
            {
                return NotFound(new { message = "Package not found." });
            }
            return Ok(package);
        }
    }
}
