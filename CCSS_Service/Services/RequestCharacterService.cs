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
    public class RequestCharacterService
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
                TotalPrice = character.Quantity * character.Price,
            };
        }
    }
}
