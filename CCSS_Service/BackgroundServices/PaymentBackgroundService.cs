using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
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
    public class PaymentBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;
        public PaymentBackgroundService(IServiceProvider _serviceProvider, ILogger<ContractBackgroudService> _logger) 
        {
            this._serviceProvider = _serviceProvider;
            this._logger = _logger;
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
                        var _paymentRepository = scope.ServiceProvider.GetRequiredService<IPaymentRepository>();

                        List<Payment> payments = await _paymentRepository.GetAll();

                        if (payments.Any())
                        {
                            foreach (var payment in payments)
                            {
                                if (payment.Status == PaymentStatus.Pending)
                                {
                                    if (DateTime.UtcNow.AddHours(7).Date >= payment.CreatAt.GetValueOrDefault().Date.AddDays(3))
                                    {
                                        bool result = await _paymentRepository.DeletePayment(payment);
                                        if (!result)
                                        {
                                            _logger.LogInformation("Payment cannot delete");
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
