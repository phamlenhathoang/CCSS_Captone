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
    public class RequestCharacterBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public RequestCharacterBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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
                        var requestCharacterRepository = scope.ServiceProvider.GetRequiredService<IRequestCharacterRepository>();
                        var _accountRepository = scope.ServiceProvider.GetService<IAccountRepository>();
                        var _sendMail = scope.ServiceProvider.GetService<SendMail>();

                        List<RequestCharacter> requestCharacters = await requestCharacterRepository.GetAllRequestCharacter();

                        if (requestCharacters.Any())
                        {
                            foreach (var requestCharacter in requestCharacters)
                            {
                                if (requestCharacter.Status == RequestCharacterStatus.Pending)
                                {
                                    if (DateTime.Now.Date >= requestCharacter.CreateDate.GetValueOrDefault().Date)
                                    {
                                        requestCharacter.Status = RequestCharacterStatus.Busy;
                                        bool result = await requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
                                        if (!result)
                                        {
                                            throw new Exception($"Can not update status of {requestCharacter.RequestCharacterId}");
                                        }
                                        Account account = await _accountRepository.GetAccount(requestCharacter.CosplayerId);
                                        if (account != null)
                                        {
                                            await _sendMail.SendAccountCancelTaskEmail(account.Email);
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
