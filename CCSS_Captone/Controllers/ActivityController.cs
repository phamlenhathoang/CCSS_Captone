using CCSS_Repository.Entities;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ActivityController : ControllerBase
        {
            private readonly IActivityService _activityService;

            public ActivityController(IActivityService activityService)
            {
                _activityService = activityService;
            }

            // GET: api/Activity
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetAll()
            {
                var result = await _activityService.GetAllActivities();
                return Ok(result);
            }

            // GET: api/Activity/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<ActivityResponse>> GetById(string id)
            {
                var activity = await _activityService.GetActivityById(id);
                if (activity == null)
                    return NotFound();

                return Ok(activity);
            }

            // POST: api/Activity
            [HttpPost]
            public async Task<ActionResult> Create([FromBody] Activity activity)
            {
                var success = await _activityService.CreateActivity(activity);
                if (!success)
                    return BadRequest("Tạo activity thất bại");

                return CreatedAtAction(nameof(GetById), new { id = activity.ActivityId }, activity);
            }

            // PUT: api/Activity/{id}
            [HttpPut("{id}")]
            public async Task<ActionResult> Update(string id, [FromBody] Activity activity)
            {
                if (id != activity.ActivityId)
                    return BadRequest("ID không khớp");

                var success = await _activityService.UpdateActivity(activity);
                if (!success)
                    return NotFound();

                return NoContent();
            }

            // DELETE: api/Activity/{id}
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(string id)
            {
                var success = await _activityService.DeleteActivity(id);
                if (!success)
                    return NotFound();

                return NoContent();
            }
        }
    
}
