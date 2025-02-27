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
            var notifications = await notificationService.GetAllNotificationsByAccountId(accountId);
            return Ok(notifications);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(string notificationId)
        {
            var result = await notificationService.UpdateNotification(notificationId);
            return Ok(result);  
        }
    }
}
