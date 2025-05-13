using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Services;
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
    public class EventBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;
        public EventBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger) 
        {
            _logger = logger;
            _serviceProvider = serviceProvider; 
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification background service đang chạy...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var _eventRepository = scope.ServiceProvider.GetRequiredService<IEventRepository>();

                        List<Event> events = await _eventRepository.GetAllEvents(null);

                        //if (events.Any())
                        //{
                        //    foreach (var e in events)
                        //    {
                        //        if (DateTime.Now == e.EndDate)
                        //        {
                        //            if (DateTime.Now.Hour >= e.EndDate.Hour)
                        //            {
                        //                e.Event
                        //                if (account != null)
                        //                {
                        //                    await _sendMail.SendContractExpiredEmail(account.Email, contract.ContractName, account.Name);
                        //                    _logger.LogInformation($"Notification {account.Email}");
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
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
