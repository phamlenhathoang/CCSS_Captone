using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet("accountId")]
        public async Task<IActionResult> GetNotificationByAccountId(string accountId)
        {
            if (ModelState.IsValid)
            {
                var notifications = await notificationService.GetAllNotificationsByAccountId(accountId);
                return Ok(notifications);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(string notificationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await notificationService.UpdateNotification(notificationId);
            return Ok(result);
        }
    }
}
