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
        Task<string> UpdateNotification(string notificationId);
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
            List<NotificationResponse> notifications = new List<NotificationResponse>();
            var ListNotification = await notificationRepository.GetAllNotificationsByAccountId(accountId);
            foreach (var notification in ListNotification)
            {
                NotificationResponse notificationResponse = new NotificationResponse()
                {
                    Id = notification.Id,
                    AccountId = notification.AccountId,
                    Message = notification.Message,
                    IsRead = notification.IsRead,
                    IsSentMail = notification.IsSentMail,
                    CreatedAt = notification.CreatedAt.ToString("HH:mm dd/MM/yyyy")
                };
                notifications.Add(notificationResponse);
            }
            return notifications;
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

        public async Task<string> UpdateNotification(string notificationId)
        {
            if (string.IsNullOrEmpty(notificationId))
            {
                return "Need entry the notificationId";
            }
            Notification notification = await notificationRepository.GetNotification(notificationId);
            if (notification == null)
            {
                return "This notification is not found";
            }
            notification.IsRead = true;
            bool result = await notificationRepository.UpdateNotification(notification);
            return result ? "Update Success" : "Update Fail";
        }
    }
}
