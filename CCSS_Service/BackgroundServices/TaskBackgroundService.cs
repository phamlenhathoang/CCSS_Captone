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
//using Task = CCSS_Repository.Entities.Task;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Service.BackgroundServices
{
    public class TaskBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public TaskBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification background service đang chạy...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();

                        List<CCSS_Repository.Entities.Task> tasks = await taskRepository.GetAllTask();

                        if (tasks.Any())
                        {
                            foreach (var task in tasks)
                            {
                                if (task.Status == TaskStatus.Assignment)
                                {
                                    if (DateTime.Now == task.StartDate.GetValueOrDefault())
                                    {
                                        task.Status = TaskStatus.Progressing;
                                    }
                                }
                                if (task.Status == TaskStatus.Progressing)
                                {
                                    if (DateTime.Now == task.EndDate.GetValueOrDefault())
                                    {
                                        task.Status = TaskStatus.Completed;
                                    }
                                }

                                bool result = await taskRepository.UpdateTask(task);
                                if (!result)
                                {
                                    throw new Exception("Can not update status task");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi kiểm tra thông báo chưa đọc.");
                }

                await System.Threading.Tasks.Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
