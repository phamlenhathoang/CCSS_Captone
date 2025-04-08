using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;

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

        [HttpPost]
        public async Task<IActionResult> CreatePackage(PackageRequest packageResponse)
        {
            if (ModelState.IsValid)
            {
                var result = await _packageService.AddPackage(packageResponse);
                return Ok(result);
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePackage(string id, PackageRequest packageResponse)
        {
            if (ModelState.IsValid)
            {
                var result = await _packageService.UpdatePackage(id, packageResponse);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePackage(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _packageService.DeletePackage(id);
            return Ok(result);
        }
    }
}
