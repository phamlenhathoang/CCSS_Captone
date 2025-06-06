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
                        var eventRepository = scope.ServiceProvider.GetRequiredService<IEventRepository>();

                        List<Event> events = await eventRepository.GetAllEvents(null);

                        if (events.Any())
                        {
                            foreach (var e in events)
                            {
                                if (e.Status == EventStatus.Progressing)
                                {
                                    if (DateTime.UtcNow.AddHours(7).Date == e.EndDate)
                                    {
                                        if(DateTime.UtcNow.AddHours(7).Hour == e.EndDate.Hour)
                                        {
                                            e.Status = EventStatus.Completed;
                                            bool result = await eventRepository.UpdateEvent(e);
                                            if (!result)
                                            {
                                                throw new Exception($"Can not update status of {e.EventId}");
                                            }
                                        }
                                    }
                                }

                                if(e.Status == EventStatus.Pending)
                                {
                                    if (DateTime.Now.Date == e.StartDate.AddDays(-1))
                                    {
                                        e.Status = EventStatus.StopSell;
                                        bool result = await eventRepository.UpdateEvent(e);
                                        if (!result)
                                        {
                                            throw new Exception($"Can not update status of {e.EventId}");
                                        }
                                    }
                                }

                                if(e.StartDate.Date == DateTime.Now.Date)
                                {
                                    if(e.StartDate.Hour == DateTime.Now.Hour)
                                    {
                                        e.Status = EventStatus.Progressing;
                                        bool result = await eventRepository.UpdateEvent(e);
                                        if (!result)
                                        {
                                            throw new Exception($"Can not update status of {e.EventId}");
                                        }
                                    }
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
