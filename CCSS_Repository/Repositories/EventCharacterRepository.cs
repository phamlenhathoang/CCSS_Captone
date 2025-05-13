using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IEventCharacterRepository
    {
        Task<List<EventCharacter>> GetAllEventCharacters();
        Task<EventCharacter> GetEventCharacterById(string id);
        Task<bool> AddEventCharacter(EventCharacter eventCharacter);
        Task<bool> UpdateEventCharacter(EventCharacter eventCharacter);
        Task<bool> DeleteEventCharacter(string id);
        Task<List<EventCharacter>> GetEventCharacterByCharacterId(string characterId);
    }

    public class EventCharacterRepository : IEventCharacterRepository
    {
        private readonly CCSSDbContext _dbContext;

        public EventCharacterRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Lấy tất cả các EventCharacter
        /// </summary>
        public async Task<List<EventCharacter>> GetAllEventCharacters()
        {
            return await _dbContext.EventCharacters
                .Include(ec => ec.Event)
                .Include(ec => ec.Character)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy EventCharacter theo ID
        /// </summary>
        public async Task<EventCharacter> GetEventCharacterById(string id)
        {
            return await _dbContext.EventCharacters
                .Include(ec => ec.Event)
                .Include(ec => ec.Character)
                .FirstOrDefaultAsync(ec => ec.EventCharacterId == id);
        }

        /// <summary>
        /// Thêm mới một EventCharacter
        /// </summary>
        public async Task<bool> AddEventCharacter(EventCharacter eventCharacter)
        {
            if (eventCharacter == null)
                return false;

            await _dbContext.EventCharacters.AddAsync(eventCharacter);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Cập nhật EventCharacter
        /// </summary>
        public async Task<bool> UpdateEventCharacter(EventCharacter eventCharacter)
        {
            var existingEventCharacter = await _dbContext.EventCharacters.FindAsync(eventCharacter.EventCharacterId);
            if (existingEventCharacter == null)
                return false;

            _dbContext.Entry(existingEventCharacter).CurrentValues.SetValues(eventCharacter);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Xóa EventCharacter theo ID
        /// </summary>
        public async Task<bool> DeleteEventCharacter(string id)
        {
            var eventCharacter = await _dbContext.EventCharacters.FindAsync(id);
            if (eventCharacter == null)
                return false;

            _dbContext.EventCharacters.Remove(eventCharacter);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<EventCharacter>> GetEventCharacterByCharacterId(string characterId)
        {
            return await _dbContext.EventCharacters.Include(ec => ec.Event).Where(ec => ec.CharacterId.Equals(characterId) && ec.Event.IsActive == false).ToListAsync();
        }
    }
}
