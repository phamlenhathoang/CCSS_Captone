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
    public class OrderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public OrderBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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
                        var _orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                        List<Order> orders = await _orderRepository.GetAllOrders();

                        if (orders.Any())
                        {
                            foreach (var order in orders)
                            {
                                if (order.OrderStatus == OrderStatus.Pending)
                                {
                                    if (DateTime.Now.Date >= order.OrderDate.GetValueOrDefault().Date.AddDays(3))
                                    {
                                        bool result = await _orderRepository.DeleteOrder(order.OrderId);
                                        if (!result)
                                        {
                                            _logger.LogInformation($"Không thể xóa {order.OrderId}");
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
