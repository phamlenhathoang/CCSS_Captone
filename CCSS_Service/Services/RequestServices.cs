using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Services
{
    public interface IRequestServices
    {
        Task<List<Request>> GetAllRequest();
        Task<Request> GetRequestById(string id);
        Task<string> DeleteRequest(string id);
        Task<string> AddRequest(RequestDtos requestDtos, RequestDescription requestDescription);
    }
    public class RequestServices : IRequestServices
    {
        private readonly IRequestRepository _repository;
        private readonly IRequestCharacterRepository _requestCharacterRepository;

        public RequestServices(IRequestRepository repository, IRequestCharacterRepository requestCharacterRepository)
        {
            _repository = repository;
            _requestCharacterRepository = requestCharacterRepository;
        }

        public async Task<List<Request>> GetAllRequest()
        {
            return await _repository.GetAllRequest();
        }

        public async Task<Request> GetRequestById(string id)
        {
            return await _repository.GetRequestById(id);
        }

        public async Task<string> AddRequest(RequestDtos requestDtos, RequestDescription requestDescription)
        {
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            if (!string.IsNullOrEmpty(requestDtos.StartDate) || !string.IsNullOrEmpty(requestDtos.EndDate))
            {
                string[] dateFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                bool isValidDate = DateTime.TryParseExact(requestDtos.StartDate, dateFormats,
                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                          System.Globalization.DateTimeStyles.None,
                                                          out StartDate);


                bool isValidEndDate = DateTime.TryParseExact(requestDtos.EndDate, dateFormats,
                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                          System.Globalization.DateTimeStyles.None,
                                                          out EndDate);
                if (!isValidDate || !isValidEndDate)
                {
                    return "Date format is incorrect. Please enter right format DateTime ";
                }
                if (StartDate < DateTime.Now.Date)
                {
                    return "Start date cannot be in the past.";
                }

                if (EndDate < DateTime.Now.Date)
                {
                    return "End date cannot be in the past.";
                }

                if (StartDate > EndDate)
                {
                    return "End date must be greater than event date.";
                }
            }
            if (requestDtos == null)
            {
                return "Need fill request";
            }

            var newRequest = new Request()
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = requestDtos.AccountId,
                Name = requestDtos.Name,
                Price = requestDtos.Price,
                Status = RequestStatus.Pending,
                StartDate = StartDate,
                EndDate = EndDate,
                Location = requestDtos.Location,
                ServiceId = requestDtos.ServiceId,
                ContractId = null,
            };
            if (requestDescription == RequestDescription.RentCosplayer)
            {
                newRequest.Description = RequestDescription.RentCosplayer;
                await _repository.AddRequest(newRequest);
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    var characteInRequest = requestDtos.ListRequestCharacters.Select(r => new RequestCharacter
                    {
                        RequestCharacterId = Guid.NewGuid().ToString(),
                        RequestId = newRequest.RequestId,
                        CharacterId = r.CharacterId,
                        CreateDate = newRequest.StartDate,
                        CosplayerId = r.CosplayerId,
                    }).ToList();

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
            }
            else if (requestDescription == RequestDescription.CreateEvent)
            {
                newRequest.Description = RequestDescription.CreateEvent;
                await _repository.AddRequest(newRequest);
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    var characteInRequest = requestDtos.ListRequestCharacters.Select(r => new RequestCharacter
                    {
                        RequestCharacterId = Guid.NewGuid().ToString(),
                        RequestId = newRequest.RequestId,
                        CharacterId = r.CharacterId,
                        CreateDate = newRequest.StartDate,
                        CosplayerId = null,

                    }).ToList();

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
            }
            else
            {
                newRequest.Description = RequestDescription.RentCostumes;
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    var characteInRequest = requestDtos.ListRequestCharacters.Select(r => new RequestCharacter
                    {
                        RequestCharacterId = Guid.NewGuid().ToString(),
                        RequestId = newRequest.RequestId,
                        CharacterId = r.CharacterId,
                        CreateDate = newRequest.StartDate,
                        CosplayerId = null,

                    }).ToList();

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
                await _repository.AddRequest(newRequest);
            }

            return "Add Request Success";
        }

        //public async Task UpdateRequest(Request request)
        //{
        //   await _repository.AddRequest(request);
        //}

        public async Task<string> DeleteRequest(string id)
        {
            var request = await GetRequestById(id);
            if (request == null)
            {
                return "Request not found";
            }
            await _repository.DeleteRequest(request);
            return "Delete Request Success";
        }


    }
}
