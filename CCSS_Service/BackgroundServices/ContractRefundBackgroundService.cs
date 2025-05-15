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
                        var _contractRefundRepository = scope.ServiceProvider.GetRequiredService<IContractRefundRepository>();
                        var _characterRepository = scope.ServiceProvider.GetRequiredService<ICharacterRepository>();
                        var _accountRepository = scope.ServiceProvider.GetService<IAccountRepository>();
                        var _sendMail = scope.ServiceProvider.GetService<SendMail>();

                        List<Contract> contracts = await _contractRepository.GetContracts();

                        if (contracts.Any())
                        {
                            foreach (var contract in contracts)
                            {
                                if (contract.DeliveryStatus == DeliveryStatus.Received)
                                {
                                    if (DateTime.Now.Date >= contract.Request.EndDate.Date.AddDays(1) && DateTime.Now.Date < contract.Request.EndDate.Date.AddDays(9))
                                    {
                                        double totalDay = (DateTime.Now - contract.Request.EndDate.AddDays(1)).TotalDays;
                                        double totalPrice = 0;

                                        foreach (ContractCharacter contractCharacter in contract.ContractCharacters)
                                        {
                                            Character character = await _characterRepository.GetCharacter(contractCharacter.CharacterId);
                                            if (character != null)
                                            {
                                                _logger.LogInformation("Character does not exist");
                                            }
                                            totalPrice += (double) character.Price;

                                        }

                                        if (contract.ContractRefund == null)
                                        {
                                            ContractRefund contractRefund = new ContractRefund
                                            {
                                                ContractId = contract.ContractId,
                                                CreateDate = DateTime.Now,
                                                Price = totalPrice * totalDay,
                                                Description = $"It's overdue {totalDay}",
                                            };

                                            bool checkAdd = await _contractRefundRepository.AddContractRefund(contractRefund);

                                            if (!checkAdd)
                                            {
                                                throw new Exception("Can not add ContractRefund");
                                            }
                                        }

                                        if(contract.ContractRefund != null)
                                        {
                                            contract.ContractRefund.Price = totalPrice * totalDay;
                                            contract.ContractRefund.UpdateDate = DateTime.Now;
                                            contract.ContractRefund.Description = $"It's overdue {totalDay}";

                                            bool checkUpdate = await _contractRefundRepository.UpdateContractRefund(contract.ContractRefund);

                                            if (!checkUpdate)
                                            {
                                                throw new Exception("Can not add ContractRefund");
                                            }
                                        }
                                    }

                                    if(DateTime.Now.Date == contract.Request.EndDate.Date.AddDays(9))
                                    {
                                        contract.ContractRefund.UpdateDate = DateTime.Now;
                                        contract.ContractRefund.Description = "Lock Account";

                                        bool checkUpdate = await _contractRefundRepository.UpdateContractRefund(contract.ContractRefund);

                                        if (!checkUpdate)
                                        {
                                            throw new Exception("Can not add ContractRefund");
                                        }

                                        contract.ContractStatus = ContractStatus.RefundOverdue;

                                        bool checkUpdateContract = await _contractRepository.UpdateContract(contract);

                                        if (!checkUpdateContract)
                                        {
                                            throw new Exception("Can not update Contract");
                                        }

                                        Account account = await _accountRepository.GetAccount(contract.CreateBy);
                                        if (account != null)
                                        {
                                            throw new Exception("Account does not exist");
                                        }

                                        account.IsLock = true;

                                        bool checkUpdateAccount = await _accountRepository.UpdateAccount(account);

                                        if (!checkUpdateAccount)
                                        {
                                            throw new Exception("Can not update Account");
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
