using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Models.Request;
using CCSS_Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICharacterService
    {
        Task<CharacterResponse> GetCharacterByIdAsync(string characterId);
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<bool> AddCharacterAsync(CharacterRequest character);
        Task<bool> UpdateCharacterAsync(string id, CharacterRequest character);
        Task<bool> DeleteCharacterAsync(string characterId);
    }
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private IMapper _mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<CharacterResponse> GetCharacterByIdAsync(string characterId)
        {
            return _mapper.Map<CharacterResponse>(await _characterRepository.GetCharacterByIdAsync(characterId));
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
        {
            return _mapper.Map<List<CharacterResponse>>(await _characterRepository.GetAllCharactersAsync());
        }

        public async Task<bool> AddCharacterAsync(CharacterRequest character)
        {
           
            return await _characterRepository.AddCharacterAsync(_mapper.Map<Character>(character));
            
        }

        public async Task<bool> UpdateCharacterAsync(string id, CharacterRequest character)
        {
            var existingCharacter = await _characterRepository.GetCharacterByIdAsync(id); // Gọi await
            if (existingCharacter != null)
            {
                _mapper.Map(character, existingCharacter);

                // Gọi repository để cập nhật
                return await _characterRepository.UpdateCharacterAsync(existingCharacter);
            }

            // Trả về false nếu không tìm thấy nhân vật
            return false;
        }

        public async Task<bool> DeleteCharacterAsync(string characterId)
        {
            return await _characterRepository.DeleteCharacterAsync(characterId);
        }
    }
}
