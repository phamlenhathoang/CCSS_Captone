using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Services;
using Google.Apis.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.BackgroundServices
{
    public class NotificationBackgroundService : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(IServiceProvider serviceProvider, ILogger<NotificationBackgroundService> logger)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification background service đang chạy...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        //var dbContext = scope.ServiceProvider.GetRequiredService<CCSSDbContext>();

                        //// Lấy thông báo chưa đọc
                        //var unreadNotifications = dbContext.Notifications
                        //    .Where(n => n.IsRead)
                        //    .ToList();

                        var _notificationRepository = scope.ServiceProvider.GetRequiredService<INotificationRepository>();
                        var _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        List<Notification> notificationList = await _notificationRepository.GetNotifications();

                        if (notificationList.Any())
                        {
                            foreach (var notification in notificationList)
                            {
                                if(DateTime.Now.Date >= notification.CreatedAt.Date)
                                {
                                    await _emailService.SendEmailAsync(notification.Account.Email, "New task", $"You have new task. Please check in the system to check about your task", true);
                                    _logger.LogInformation($"Notification {notification.Account.Email}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi kiểm tra thông báo chưa đọc.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
