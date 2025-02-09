using CCSS_Service.Models.Response;
using CCSS_Service.Models.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventResponse>>> GetAllCharacters()
        {
            var events = await eventService.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> GetEventById(string id)
        {
            var character = await eventService.GetEventById(id);
            if (character == null)
            {
                return NotFound(new { message = "Character not found." });
            }
            return Ok(character);
        }
    }
}
