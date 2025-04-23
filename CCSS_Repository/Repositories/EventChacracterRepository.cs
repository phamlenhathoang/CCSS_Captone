using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IEventChacracterRepository
    {
        Task<EventCharacter> GetEventCharacterById(string id); 
    }
    public class EventChacracterRepository : IEventChacracterRepository
    {
        private readonly CCSSDbContext dbContext;
        public EventChacracterRepository(CCSSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EventCharacter> GetEventCharacterById(string id)
        {
            return await dbContext.EventCharacters.Include(e => e.Event).Include(e => e.Character).Include(e => e.Task).ThenInclude(e => e.Account).FirstOrDefaultAsync(e => e.EventCharacterId.Equals(id)); 
        }
    }
}
