using CCSS_Repository.Entities;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpPut]
        public async Task<ActionResult<CharacterResponse>> UpdateStatusTask(string taskId, int taskStatus, string accountId)
        {
            var task = await taskService.UpdateStatusTask(taskId, taskStatus, accountId);
            if (!task)
            {
                return BadRequest(new { message = "Update task does not success." });
            }
            return Ok(task);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<CharacterResponse>> DeleteTask(string taskId)
        {
            var task = await taskService.DeleteTask(taskId);
            if (!task)
            {
                return BadRequest(new { message = "Delete task does not success." });
            }
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<CharacterResponse>> GetTask(string taskId)
        {
            var task = await taskService.GetTask(taskId);
            if (task == null)
            {
                return NotFound(new { message = "Update task does not success." });
            }
            return Ok(task);
        }
    }
}
