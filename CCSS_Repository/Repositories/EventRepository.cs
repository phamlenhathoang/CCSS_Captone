using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IEventRepsository
    {
        Task<List<Event>> GetEvents();
        Task<Event> GetEventById(string eventId);
    }
    public class EventRepository : IEventRepsository
    {
        private readonly CCSSDBContext _dbContext;

        public EventRepository(CCSSDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Event>> GetEvents()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(string eventId)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.EventId == eventId);
        }
    }
}
