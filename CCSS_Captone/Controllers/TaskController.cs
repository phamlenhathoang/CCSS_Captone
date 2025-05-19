using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Globalization;

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
        //    var task = await taskService.AddTask(taskRequests.AddTaskEventRequests, taskRequests.AddTaskContractRequests);
        //    return Ok(task);
        //}

        [HttpGet]
        public async Task<ActionResult> GetAllTask()
        {
            var task = await taskService.GetAllTasks();
            return Ok(task);
        }

        [HttpPut("taskId")]
        public async Task<ActionResult> UpdateStatusTaskByTaskId(string taskId, string status)
        {
            var task = await taskService.UpdateStatusTaskByTaskId(taskId, status);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTaskContractByManager(List<AddTaskContractRequest> contractCharacters, string requestId)
        {
            var task = await taskService.AddTaskContractByManager(contractCharacters, requestId);
            return Ok(task);
        }

        [HttpGet("totalHour")]
        public async Task<ActionResult> TotalHour(string startDate, string endDate)
        {
            double totalHours = 0;
            string format = "HH:mm dd/MM/yyyy";
            CultureInfo culture = CultureInfo.InvariantCulture;

            DateTime start = DateTime.ParseExact(startDate, format, culture);
            DateTime end = DateTime.ParseExact(endDate, format, culture);

            while (start.Date <= end.Date)
            {
                DateTime nextDay = start.Date.AddDays(1); // 00:00 ngày hôm sau
                DateTime effectiveEnd = (nextDay < end) ? nextDay : end; // Xác định điểm dừng trong ngày

                double hoursInDay = (effectiveEnd - start).TotalHours;
                hoursInDay = Math.Min(hoursInDay, 8); // Giới hạn tối đa 8 tiếng

                totalHours += hoursInDay;
                start = nextDay; // Chuyển sang ngày tiếp theo
            }

            return Ok(totalHours);
        }


        [HttpPut("EventId")]
        public async Task<ActionResult> DeleteAllTaskByEventId(string eventId)
        {
            var task = await taskService.DeleteAllTaskByEventId(eventId);
            return Ok(task);
        }

        [HttpGet("requestId")]
        public async Task<ActionResult> GetAllTaskByRequestId(string requestId)
        {
            var task = await taskService.GetAllTaskByRequestId(requestId);
            return Ok(task);
        }

        [HttpGet("GetAllTaskByContractId")]
        public async Task<ActionResult> GetAllTaskByContractId(string contractId)
        {
            var task = await taskService.GetAllTaskByContractId(contractId);
            return Ok(task);
        }
    }
}
