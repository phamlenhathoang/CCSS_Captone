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
    public class ContractImageBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public ContractImageBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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
                        var _contractService = scope.ServiceProvider.GetRequiredService<IContractServices>();
                        var _contractImageRepository = scope.ServiceProvider.GetRequiredService<IContractImageRepository>();
                        var _contractRepository = scope.ServiceProvider.GetRequiredService<IContractRespository>();

                        List<ContractImage> contractImages = await _contractImageRepository.GetListContractImageByStatusRefundMoney();

                        if (contractImages.Any())
                        {
                            foreach (var contractImage in contractImages)
                            {
                                if (contractImage.CreateDate.AddDays(1) == DateTime.Now)
                                {
                                    Contract contract = await _contractRepository.GetContractById(contractImage.ContractId);

                                    if(contract.ContractStatus != ContractStatus.Completed)
                                    {
                                        bool result = await _contractService.UpdateStatusContract(contract.ContractId, ContractStatus.Completed.ToString(), null, null);
                                        if (!result)
                                        {
                                            _logger.LogInformation("Can not update contract");
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
