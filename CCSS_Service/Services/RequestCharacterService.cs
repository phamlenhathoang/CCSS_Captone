using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IRequestCharacterService
    {
        Task<RequestCharacterResponse> GetCharacterInRequestById(string Id);
        Task<List<RequestCharacter>> GetAllCharacterInRequest();
        Task<string> AddCharacterInRequest(CharacterInRequest characterInRequest);
        Task<string> UpdateCharactetInRRequest(string requestCharacterId, CharacterInRequest characterInRequest);
        Task<string> DeleteCharacterInRequest(string requestCharacterId);
        Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId);
        Task<List<RequestCharacterResponse>> GetRequestCharacterByCosplayer(string cosplayerId);
        Task<string> UpdateStatus(string requestcharacterId, RequestCharacterStatus status);
        Task<string> CheckRequestChracter(string requestId);
    }

    public class RequestCharacterService : IRequestCharacterService
    {
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IRequestDatesRepository _requestDatesRepository;
        private readonly IRequestRepository _requestRepository;

        public RequestCharacterService(IRequestCharacterRepository requestCharacterRepository, ICharacterRepository characterRepository, IRequestDatesRepository requestDatesRepository, IRequestRepository requestRepository)
        {
            _requestCharacterRepository = requestCharacterRepository;
            _characterRepository = characterRepository;
            _requestDatesRepository = requestDatesRepository;
            _requestRepository = requestRepository;
        }

        public async Task<List<RequestCharacter>> GetAllCharacterInRequest()
        {
            return await _requestCharacterRepository.GetAllRequestCharacter();
        }


        public async Task<string> CheckRequestChracter(string requestId)
        {
            var request = await _requestRepository.GetRequestById(requestId);
            if (request == null)
            {
                return "Request is not found";
            }
            var listRequestCharacter = await _requestCharacterRepository.GetListCharacterByRequest(requestId);
            if (listRequestCharacter == null)
            {
                return "This Request do not have requestCharacter";
            }
            foreach (var character in listRequestCharacter)
            {
                if (character.Status == RequestCharacterStatus.Busy)
                {
                    request.Status = RequestStatus.Pending;
                    await _requestRepository.UpdateRequest(request);

                    return "This request has a requestCharacter busy, need to wait customer change requestCharacter";
                }
            }
            return "This request can change status";

        }

        public async Task<RequestCharacterResponse> GetCharacterInRequestById(string Id)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(Id);
            var character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
            RequestCharacterResponse requestCharacterResponse = new RequestCharacterResponse()
            {
                RequestCharacterId = requestCharacter.RequestCharacterId,
                RequestId = requestCharacter.RequestId,
                CharacterId = requestCharacter.CharacterId,
                CharacterName = character.CharacterName,
                MaxHeight = character.MaxHeight,
                MinHeight = character.MinHeight,
                MaxWeight = character.MaxWeight,
                MinWeight = character.MinWeight,
                Status = requestCharacter.Status,
                Reason = requestCharacter.Reason,
                TotalPrice = requestCharacter.TotalPrice,
                CreateDate = requestCharacter.CreateDate?.ToString("dd/MM/yyyy"),
                UpdateDate = requestCharacter.UpdateDate?.ToString("dd/MM/yyyy"),
                Description = requestCharacter.Description,
                CosplayerId = requestCharacter.CosplayerId,
                Quantity = requestCharacter.Quantity,
                RequestDateInCharacterResponses = requestCharacter.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
                {
                    TimeSpan hourDuration = rd.EndDate - rd.StartDate;
                    decimal totalhours = (decimal)hourDuration.TotalHours;
                    return new RequestDateResponse
                    {
                        RequestDateId = rd.RequestDateId,
                        RequestCharacterId = rd.RequestCharacterId,
                        StartDate = rd.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        EndDate = rd.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        Status = rd.Status,
                        Reason = rd.Reason,
                        TotalHour = totalhours,
                    };
                }).ToList(),
            };
            return requestCharacterResponse;
        }

        public async Task<List<RequestCharacterResponse>> GetRequestCharacterByCosplayer(string cosplayerId)
        {
            List<RequestCharacterResponse> requestCharacters = new List<RequestCharacterResponse>();
            var listrequestcharacter = await _requestCharacterRepository.GetRequestCharacterByCosplayer(cosplayerId);
            foreach (var item in listrequestcharacter)
            {
                var character = await _characterRepository.GetCharacter(item.CharacterId);
                var listrequestdates = await _requestDatesRepository.GetAllRequestDates();
                RequestCharacterResponse requestchracter = new RequestCharacterResponse()
                {
                    RequestCharacterId = item.RequestCharacterId,
                    RequestId = item.RequestId,
                    CharacterId = item.CharacterId,
                    CharacterName = character.CharacterName,
                    MaxHeight = character.MaxHeight,
                    MinHeight = character.MinHeight,
                    MaxWeight = character.MaxWeight,
                    MinWeight = character.MinWeight,
                    Status = item.Status,
                    Reason = item.Reason,
                    TotalPrice = item.TotalPrice,
                    CreateDate = item.CreateDate?.ToString("dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate?.ToString("dd/MM/yyyy"),
                    Description = item.Description,
                    CosplayerId = item.CosplayerId,
                    Quantity = item.Quantity,
                    RequestDateInCharacterResponses = item.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
                    {
                        TimeSpan hourDuration = rd.EndDate - rd.StartDate;
                        decimal totalhours = (decimal)hourDuration.TotalHours;
                        return new RequestDateResponse
                        {
                            RequestDateId = rd.RequestDateId,
                            RequestCharacterId = rd.RequestCharacterId,
                            StartDate = rd.StartDate.ToString("HH:mm dd/MM/yyyy"),
                            EndDate = rd.EndDate.ToString("HH:mm dd/MM/yyyy"),
                            Status = rd.Status,
                            Reason = rd.Reason,
                            TotalHour = totalhours,
                        };
                    }).ToList(),

                };
                requestCharacters.Add(requestchracter);
            }
            return requestCharacters;
        }

        public async Task<string> UpdateStatus(string requestcharacterId, RequestCharacterStatus status)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestcharacterId);
            if (requestCharacter == null)
            {
                return "request Character is not found";
            }

            requestCharacter.Status = status;
            requestCharacter.UpdateDate = DateTime.Now;

            var result = await _requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
            return result ? "Update Successfull" : "Update Failed";
        }

        public async Task<string> AddCharacterInRequest(CharacterInRequest characterInRequest)
        {
            if (characterInRequest == null)
            {
                return "Request Character is null here";
            }
            if (characterInRequest.CharacterId == null && characterInRequest.RequestId == null)
            {
                return "This field is need to required";
            }
            var character = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
            if (character == null)
            {
                return "Character is not found";
            }
            var newCharacterInRequest = new RequestCharacter()
            {
                RequestCharacterId = Guid.NewGuid().ToString(),
                CharacterId = characterInRequest.CharacterId,
                RequestId = characterInRequest.RequestId,
                Quantity = characterInRequest.Quantity,
                TotalPrice = characterInRequest.Quantity * character.Price,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                CosplayerId = null,
            };
            var result = await _requestCharacterRepository.AddRequestCharacter(newCharacterInRequest);
            return result ? "Character In Request is Add Successfully" : "Add Character in Requst Failed";
        }

        public async Task<string> UpdateCharactetInRRequest(string requestCharacterId, CharacterInRequest characterInRequest)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestCharacterId);
            var character = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
            if (requestCharacter == null)
            {
                return "Characte in request is not found";
            }
            requestCharacter.CharacterId = characterInRequest.CharacterId;
            requestCharacter.CosplayerId = characterInRequest.CosplayerId;
            requestCharacter.Quantity = characterInRequest.Quantity;
            requestCharacter.TotalPrice = characterInRequest.Quantity * character.Price;
            requestCharacter.UpdateDate = DateTime.Now;
            requestCharacter.Description = characterInRequest.Description;

            var result = await _requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
            return result ? "Update Success" : "Update Failed";

        }

        public async Task<string> DeleteCharacterInRequest(string requestCharacterId)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestCharacterId);
            if (requestCharacter == null)
            {
                return "Character is not found in Request";
            }
            var result = await _requestCharacterRepository.DeleteRequestCharacter(requestCharacter);
            return result ? "Delete Success" : "Delete Failed";
        }

        public async Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId)
        {
            return await _requestCharacterRepository.GetRequestCharacter(requestId, characterId);
        }
    }
}
