using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface INotificationService
    {
        Task<bool> UpdateNotification(string notificationId);
        Task<List<NotificationResponse>> GetAllNotificationsByAccountId(string accountId);
        Task<string> SendNotification(string accountId, string message);
    }
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper) 
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<List<NotificationResponse>> GetAllNotificationsByAccountId(string accountId)
        {
            List<Notification> notifications = await notificationRepository.GetAllNotificationsByAccountId(accountId);
            return mapper.Map<List<NotificationResponse>>(notifications);
        }

        public async Task<string> SendNotification(string accountId, string message)
        {
            var notification = new Notification()
            {
                Id = Guid.NewGuid().ToString(),
                AccountId = accountId,
                Message = message,
                IsRead = false,
                IsSentMail = false,
                CreatedAt = DateTime.UtcNow,
            };
            var result = await notificationRepository.AddNotification(notification);

            return result ? "Create Success" : "Create Failed";
        }

        public async Task<bool> UpdateNotification(string notificationId)
        {
            if(string.IsNullOrEmpty(notificationId))
            {
                return false;
            }
            
            Notification notification = await notificationRepository.GetNotification(notificationId);
            if (notification == null)
            {
                return false;    
            }

            notification.IsRead = true; 
            bool result = await notificationRepository.UpdateNotification(notification);
            return result;
        }
    }
}
