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
            return await _context.Characters.ToListAsync();    
        }

        public async Task<Character> GetCharacter(string characterId)
        {
            return await _context.Characters.FirstOrDefaultAsync(c => c.CharacterId == characterId);
        }
    }
}
