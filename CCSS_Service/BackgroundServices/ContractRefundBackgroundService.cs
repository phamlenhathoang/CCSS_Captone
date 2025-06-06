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
    public class ContractRefundBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public ContractRefundBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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
                        var _contractRepository = scope.ServiceProvider.GetRequiredService<IContractRespository>();
                        var _accountRepository = scope.ServiceProvider.GetService<IAccountRepository>();
                        var _sendMail = scope.ServiceProvider.GetService<SendMail>();

                        List<Contract> contracts = await _contractRepository.GetContracts();

                        if (contracts.Any())
                        {
                            foreach (var contract in contracts)
                            {
                                if (contract.DeliveryStatus == DeliveryStatus.Received)
                                {
                                    if (DateTime.UtcNow.AddHours(7).Date == contract.Request.EndDate.Date.AddDays(1))
                                    {
                                        contract.ContractStatus = ContractStatus.RefundOverdue;
                                        contract.Amount = 0;

                                        bool result = await _contractRepository.UpdateContract(contract);
                                        if (!result)
                                        {
                                            _logger.LogInformation("Can not update contract");
                                        }

                                        Account account = await _accountRepository.GetAccount(contract.Request.AccountId);
                                        if (account == null) 
                                        {
                                            _logger.LogInformation("Account does not exist");
                                        }

                                        bool checkMail = await _sendMail.SendCustomerRefundOverdueContract(account.Email, contract.Request.EndDate.ToString("dd/MM/yyyy"));

                                        if (!checkMail)
                                        {
                                            _logger.LogInformation($"Can not send mail for {account.AccountId}");
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
