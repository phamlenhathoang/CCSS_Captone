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

        //[HttpPut]
        //public async Task<ActionResult<TaskResponse>> UpdateStatusTask(string taskId, int taskStatus, string accountId)
        //{
        //    var task = await taskService.UpdateStatusTask(taskId, taskStatus, accountId);
        //    return Ok(task);
        //}

        //[HttpDelete("id")]
        //public async Task<ActionResult<TaskResponse>> DeleteTask(string taskId)
        //{
        //    var task = await taskService.DeleteTask(taskId);
        //    return Ok(task);
        //}

        //[HttpGet("taskId")]
        //public async Task<ActionResult<TaskResponse>> GetTask(string taskId)
        //{
        //    var task = await taskService.GetTask(taskId);
        //    if (task == null)
        //    {
        //        return NotFound(new { message = "Update task does not success." });
        //    }
        //    return Ok(task);
        //}

        //[HttpGet("accountId")]
        //public async Task<ActionResult> ViewAllTaskByAccountId(string accountId, string? taskId)
        //{
        //    var task = await taskService.ViewAllTaskByAccountId(accountId, taskId);
        //    return Ok(task);
        //}

        [HttpPost]
        public async Task<ActionResult<TaskResponse>> AddTask(List<AddTaskEventRequest>? addTaskEventRequests, List<AddTaskContractRequest>? addTaskContractRequests)
        {
            var task = await taskService.AddTask(addTaskEventRequests, addTaskContractRequests);
            return Ok(task);
        }

        //[HttpGet("contractId")]
        //public async Task<ActionResult> ViewAllTaskByContractId(string contractId)
        //{
        //    var task = await taskService.ViewAllTaskByContractId(contractId);
        //    return Ok(task);
        //}
    }
}
