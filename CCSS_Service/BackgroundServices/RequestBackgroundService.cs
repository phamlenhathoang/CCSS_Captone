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
    public class RequestBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ContractBackgroudService> _logger;

        public RequestBackgroundService(IServiceProvider serviceProvider, ILogger<ContractBackgroudService> logger)
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
                        var _requestRepository = scope.ServiceProvider.GetRequiredService<IRequestRepository>();
                        var _requestCharacterRepository = scope.ServiceProvider.GetRequiredService<IRequestCharacterRepository>();
                        var _requestDateRepositoy = scope.ServiceProvider.GetRequiredService<IRequestDatesRepository>();

                        List<Request> requests = await _requestRepository.GetAllRequest();

                        if (requests.Any())
                        {
                            foreach (var request in requests)
                            {
                                if (request.Status == RequestStatus.Cancel)
                                {
                                    if (DateTime.Now.Date >= request.CreatedDate.GetValueOrDefault().Date.AddDays(3))
                                    {
                                        var listRequestCharacter = await _requestCharacterRepository.GetListCharacterByRequest(request.RequestId);
                                        foreach (var character in listRequestCharacter)
                                        {
                                            await _requestDateRepositoy.DeleteListRequestDateByRequestCharacterId(character.RequestCharacterId);
                                        }
                                        await _requestCharacterRepository.DeleteListCharacterInRequest(listRequestCharacter);
                                        await _requestRepository.DeleteRequest(request);
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
