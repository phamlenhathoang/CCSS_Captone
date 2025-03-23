using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
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
                        var _contractRepository = scope.ServiceProvider.GetRequiredService<IContractRespository>();
                        var _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                        var _accountRepository = scope.ServiceProvider.GetService<IAccountRepository>();
                        var _sendMail = scope.ServiceProvider.GetService<SendMail>();

                        List<Contract> contracts = await _contractRepository.GetContracts();

                        if (contracts.Any())
                        {
                            foreach (var contract in contracts)
                            {
                                if(contract.ContractStatus == ContractStatus.Active)
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
                                        if(account != null)
                                        {
                                            await _sendMail.SendContractExpiredEmail(account.Email, contract.ContractName, account.Name);
                                            _logger.LogInformation($"Notification {account.Email}");
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
