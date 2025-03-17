using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Services;
using Google.Apis.Storage.v1.Data;
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
    public class ContractBackgroudService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public ContractBackgroudService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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

                        var _contractRepository = scope.ServiceProvider.GetRequiredService<IContractRespository>();
                        var _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                        var _accountRepository = scope.ServiceProvider.GetService<IAccountRepository>();

                        List<Contract> contracts = await _contractRepository.GetContracts();

                        if (contracts.Any())
                        {
                            foreach (var contract in contracts)
                            {
                                if (DateTime.Now.Date >= contract.CreateDate.GetValueOrDefault().Date.AddDays(3))
                                {
                                    contract.ContractStatus = ContractStatus.Expired;
                                    bool result = await _contractRepository.UpdateContract(contract);
                                    if (!result)
                                    {
                                        throw new Exception($"Can not update status of {contract.ContractId}");
                                    }
                                    Account account = await _accountRepository.GetAccount(contract.CreateBy);
                                    await _emailService.SendEmailAsync(account.Email, "New task", $"You have new task. Please check in the system to check about your task", true);
                                    _logger.LogInformation($"Notification {account.Email}");
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
