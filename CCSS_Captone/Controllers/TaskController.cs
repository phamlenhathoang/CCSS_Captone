using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
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
        public async Task<ActionResult<TaskResponse>> UpdateStatusTask(string taskId, string taskStatus, string accountId)
        {
            var task = await taskService.UpdateStatusTask(taskId, taskStatus, accountId);
            return Ok(task);
        }

        //[HttpDelete("id")]
        //public async Task<ActionResult<TaskResponse>> DeleteTask(string taskId)
        //{
        //    var task = await taskService.DeleteTask(taskId);
        //    return Ok(task);
        //}

        [HttpGet("taskId/{taskId}")]
        public async Task<ActionResult<TaskResponse>> GetTaskByTaskId(string taskId)
        {
            var task = await taskService.GetTaskByTaskId(taskId);
            if (task == null)
            {
                return NotFound(new { message = "Update task does not success." });
            }
            return Ok(task);
        }

        [HttpGet("accountId/{accountId}")]
        public async Task<ActionResult> GetTaskByAccountId(string accountId)
        {
            var task = await taskService.GetTaskByAccountId(accountId);
            return Ok(task);
        }

        //[HttpPost]
        //public async Task<ActionResult<TaskResponse>> AddTask(TaskRequest taskRequests)
        //{
        //    //var task = await taskService.AddTask(taskRequests.AddTaskEventRequests, taskRequests.AddTaskContractRequests);
        //    //return Ok(task);
        //}

        [HttpGet]
        public async Task<ActionResult> GetAllTask()
        {
            var task = await taskService.GetAllTasks();
            return Ok(task);
        }
    }
}
