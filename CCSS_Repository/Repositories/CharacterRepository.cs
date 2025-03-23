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
        Task<List<Character>> GetCharacterByCategoryId(string categoryId);
        Task<List<Character>> GetCharacters(string? characterId, string? categoryId, string? characterName, double? MaxHeight, double? MinHeight, double? Maxweight, double? MinWeight, double? MinPrice, double? MaxPrice);
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
            return await _context.Characters.Include(c => c.Category).Include(c => c.CharacterImages).FirstOrDefaultAsync(c => c.CharacterId == characterId && c.IsActive == true);
        }

        public async Task<Character> GetCharacterByCharacterName(string characterName)
        {
            return await _context.Characters.Include(c => c.Category).Include(c => c.CharacterImages).FirstOrDefaultAsync(c => c.CharacterName.ToLower() == characterName && c.IsActive == true);
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
            
            if(character.MinHeight <= a.Height && a.Height <= character.MaxHeight && character.MinWeight <= a.Weight && a.Weight <= character.MaxHeight)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Character>> GetCharacterByCategoryId(string categoryId)
        {
            return await _context.Characters.Include(i => i.CharacterImages).Where(c => c.CategoryId.Equals(c.CategoryId)).ToListAsync();
        }

        public async Task<List<Character>> GetCharacters(string? characterId, string? categoryId, string? characterName, double? MaxHeight, double? MinHeight, double? Maxweight, double? MinWeight, double? MinPrice, double? MaxPrice)
        {
            IQueryable<Character> query = _context.Characters.Include(c => c.Category).Include(c => c.CharacterImages).Where(c => c.IsActive == true);

            if (!string.IsNullOrWhiteSpace(characterId))
            {
                query = query.Where(c => c.CharacterId.Equals(characterId));
            }

            if (!string.IsNullOrWhiteSpace(categoryId))
            {
                query = query.Where(c => c.Category.CategoryId.Equals(categoryId));
            }

            if (!string.IsNullOrWhiteSpace(characterName))
            {
                query = query.Where(c => c.CharacterName.Equals(characterName));
            }

            if (MaxHeight != null)
            {
                query = query.Where(c => c.MaxHeight <= MaxHeight);
            }

            if (MinHeight != null)
            {
                query = query.Where(c => c.MinHeight >= MinHeight);
            }

            if (Maxweight != null)
            {
                query = query.Where(c => c.MaxWeight <= Maxweight);
            }

            if (MinWeight != null)
            {
                query = query.Where(c => c.MinWeight >= MinWeight);
            }

            if (MaxPrice != null)
            {
                query = query.Where(c => c.Price <= MaxPrice);
            }

            if (MinPrice != null)
            {
                query = query.Where(c => c.Price >= MinWeight);
            }

            return await query.ToListAsync();
        }
    }
}
