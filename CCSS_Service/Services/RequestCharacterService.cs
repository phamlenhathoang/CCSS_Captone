using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IRequestCharacterService
    {
        Task<RequestCharacter> GetCharacterInRequestById(string Id);
        Task<List<RequestCharacter>> GetAllCharacterInRequest();
        Task<string> AddCharacterInRequest(CharacterInRequest characterInRequest);
        Task<string> UpdateCharactetInRRequest(string requestCharacterId, CharacterInRequest characterInRequest);
        Task<string> DeleteCharacterInRequest(string requestCharacterId);
    }

    public class RequestCharacterService: IRequestCharacterService
    {
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly ICharacterRepository _characterRepository;

        public RequestCharacterService(IRequestCharacterRepository requestCharacterRepository, ICharacterRepository characterRepository)
        {
            _requestCharacterRepository = requestCharacterRepository;
            _characterRepository = characterRepository;
        }

        public async Task<List<RequestCharacter>> GetAllCharacterInRequest()
        {
            return await _requestCharacterRepository.GetAllRequestCharacter();
        }

        public async Task<RequestCharacter> GetCharacterInRequestById(string Id)
        {
            return await _requestCharacterRepository.GetRequestCharacterById(Id);
        }

        public async Task<string> AddCharacterInRequest(CharacterInRequest characterInRequest)
        {
            if(characterInRequest == null)
            {
                return "Request Character is null here";
            }
            if(characterInRequest.CharacterId == null && characterInRequest.RequestId == null)
            {
                return "This field is need to required";
            }
            var character = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
            if(character == null)
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
            if(requestCharacter == null)
            {
                return "Character is not found in Request";
            }
            var result = await _requestCharacterRepository.DeleteRequestCharacter(requestCharacter);
            return result ? "Delete Success" : "Delete Failed";
        }

    }
}
