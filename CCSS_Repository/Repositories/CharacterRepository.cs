using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacter(string characterId);
        Task<List<Character>> GetAll();
        Task<Character> GetCharacterByCharacterName(string characterName);
        Task<bool> CreateCharacter(Character character);
        Task<bool> UpdateCharacter(Character character);
        Task<bool> DeleteCharacter(Character character);
        Task<bool> CheckCharacterForAccount(Account account, string characterId);
    }
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CCSSDbContext _context;
        public CharacterRepository(CCSSDbContext cCSSDbContext)
        {
            _context = cCSSDbContext;
        }
        public async Task<List<Character>> GetAll()
        {
            return await _context.Characters.Where(x => x.IsActive == true).ToListAsync();    
        }

        public async Task<Character> GetCharacter(string characterId)
        {
            return await _context.Characters.Include(c => c.Category).FirstOrDefaultAsync(c => c.CharacterId == characterId && c.IsActive == true);
        }

        public async Task<Character> GetCharacterByCharacterName(string characterName)
        {
            return await _context.Characters.Include(c => c.Category).FirstOrDefaultAsync(c => c.CharacterName == characterName && c.IsActive == true);
        }

        public async Task<bool> CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCharacter(Character character)
        {
            _context.Characters.Remove(character);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckCharacterForAccount(Account a, string characterId)
        {
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.CharacterId.Equals(characterId) && c.IsActive == true);

            if (character == null)
            {
                return false;
            }

            if(character.MinHeight < a.Height && a.Height < character.MaxHeight && character.MinWeight < a.Weight && a.Weight < character.MaxHeight)
            {
                return true;
            }

            return false;
        }
    }
}
