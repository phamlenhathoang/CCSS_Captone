using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterByIdAsync(string characterId);
        Task<List<Character>> GetAllCharactersAsync();
        Task<bool> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(Character character);
        Task<bool> DeleteCharacterAsync(string characterId);
    }

    public class CharacterRepository : ICharacterRepository
    {
        private readonly CCSSDBContext _dbContext;

        public CharacterRepository(CCSSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Character> GetCharacterByIdAsync(string characterId)
        {
            return await _dbContext.Characters.Include(c => c.Category).Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.CharacterId == characterId);
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            return await _dbContext.Characters.Include(c => c.Category).Include(c => c.Images).ToListAsync();
        }

        public async Task<bool> AddCharacterAsync(Character character)
        {
            await _dbContext.Characters.AddAsync(character);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCharacterAsync(Character character)
        {
            var existingCharacter = await _dbContext.Characters.FindAsync(character.CharacterId);

            if (existingCharacter == null)
            {
                return false; // Không tìm thấy entity để cập nhật
            }

            // Cập nhật các giá trị mới
            _dbContext.Entry(existingCharacter).CurrentValues.SetValues(character);

            // Lưu thay đổi
            return await _dbContext.SaveChangesAsync() > 0;
           
        }

        public async Task<bool> DeleteCharacterAsync(string characterId)
        {
            try
            {
                var character = await _dbContext.Characters.FindAsync(characterId);
                if (character != null)
                {
                    _dbContext.Characters.Remove(character);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa nhân vật: {ex.Message}");
                return false;
            }
        }

    }
}
