using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface INotificationRepository
    {
        Task<bool> AddRangeNotification(List<Notification> notifications);
        Task<bool> UpdateNotification(Notification notification);
        Task<List<Notification>> GetAllNotificationsByAccountId(string accountId);  
        Task<Notification> GetNotification(string notificationId);
        Task<List<Notification>> GetNotifications();
    }
    public class NotificationRepository : INotificationRepository
    {
        private readonly CCSSDbContext _context;

        public NotificationRepository(CCSSDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRangeNotification(List<Notification> notifications)
        {
            await _context.Notifications.AddRangeAsync(notifications);
            int result = await _context.SaveChangesAsync();
            if (result != 0)
            {
                return true;   
            }
            return false;
        }

        public async Task<List<Notification>> GetAllNotificationsByAccountId(string accountId)
        {
            return await _context.Notifications.Include(n => n.Account)
                                .Where(n => n.Account.AccountId == accountId && !n.IsRead)
                                .ToListAsync();
        }

        public async Task<Notification> GetNotification(string notificationId)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.Id == notificationId);
        }

        public async Task<List<Notification>> GetNotifications()
        {
            return await _context.Notifications.Include(x => x.Account).Where(x => !x.IsRead).ToListAsync();
        }

        public async Task<bool> UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            int result = await _context.SaveChangesAsync(); 
            return result != 0 ? true : false;
        }
    }
}
