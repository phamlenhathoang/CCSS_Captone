using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICharacterService
    {
        Task<CharacterResponse> GetCharacter(string characterId);
        Task<List<CharacterResponse>> GetAll();
    }
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            this.mapper = mapper;
        }
        public async Task<List<CharacterResponse>> GetAll()
        {
            return mapper.Map<List<CharacterResponse>>(await _characterRepository.GetAll());
        }

        public async Task<CharacterResponse> GetCharacter(string characterId)
        {
            return mapper.Map<CharacterResponse>(await _characterRepository.GetCharacter(characterId));
        }
    }
}
