using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationResponse>>> GetAll()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationResponse>> GetById(string id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null) return NotFound();
            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LocationRequest request)
        {
            var result = await _locationService.AddLocation(request);
            if (!result) return BadRequest("Cannot create location");
            return Ok("Add Success");
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(string id, [FromBody] LocationRequest request)
        //{
        //    if (id != request.LocationId)
        //        return BadRequest("ID mismatch");

        //    var location = await _locationService.GetLocationById(id);
        //    if (location == null) return NotFound();

        //    var updateEntity = _locationService.Mapper.Map<Location>(request); // Nếu Mapper public, hoặc gọi service update như cũ
        //    var result = await _locationService.UpdateLocation(updateEntity);
        //    if (!result) return BadRequest("Update failed");

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _locationService.DeleteLocation(id);
            if (!result) return NotFound();
            return Ok("Ok");
        }
    }
}
