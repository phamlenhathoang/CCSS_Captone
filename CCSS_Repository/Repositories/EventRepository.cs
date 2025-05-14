using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CCSS_Repository.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents(string searchTerm);
        Task<Event> GetEventById(string id);
        Task<List<EventCharacter>> GetEventCharactersByEventId(string eventId);

        Task<Event> GetEventByEventId(string id);
        Task<Event> GetEventByTicketId(int? ticketId);
        Task<bool> AddEvent(Event eventObj);
        Task<bool> UpdateEvent(Event eventObj);
        Task<bool> DeleteEvent(string id);
        Task<bool> DeleteEventCharactersByEventId(string id);
        Task<bool> DeleteEventActivityByEventId(string id);
        Task<bool> DeleteTicketByEventId(string id);
        Task<bool> DeleteEventImageById(string id);
        Task<bool> DeleteTicketsByEventId(string eventId);
        Task<bool> CheckEventValid(string eventId, DateTime start, DateTime end);
    }

    public class EventRepository : IEventRepository
    {
        private readonly CCSSDbContext _dbContext;

        public EventRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<List<Event>> GetAllEvents(string searchTerm)
        //{
        //    var query = _dbContext.Events.AsQueryable();

        //    // Nếu searchTerm không null hoặc không rỗng, lọc theo EventName
        //    if (!string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        query = query.Where(e => e.EventName.Contains(searchTerm));
        //    }

        //    return await query.ToListAsync();
        //}
        public async Task<List<EventCharacter>> GetEventCharactersByEventId(string eventId)
        {
            return await _dbContext.EventCharacters
                .Where(ec => ec.EventId == eventId)
                .ToListAsync();
        }
        public async Task<List<Event>> GetAllEvents(string searchTerm)
        {
            var query = _dbContext.Events
                .Where(e => e.IsActive == true) 
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(e => e.EventName.Contains(searchTerm));
            }

            
            query = query
                .Include(e => e.Ticket)
                .ThenInclude(e => e.TicketAccounts)
                .Include(e => e.EventCharacters)
                .Include(e => e.EventImages)
                .Include(e => e.EventActivities)
                .ThenInclude(e => e.Activity);

            return await query.ToListAsync();
        }
        public async Task<Event> GetEventByTicketId(int? ticketId)
        {
            return await _dbContext.Events
                .Where(e => e.IsActive == true && e.Ticket.Any(t => t.TicketId == ticketId))
                .Include(e => e.Ticket)
                .FirstOrDefaultAsync();
        }




        public async Task<Event> GetEventById(string id)
        {
            return await _dbContext.Events
                .Where(e => e.IsActive == true) // 🔥 Chỉ lấy sự kiện có IsActive == true
                .Include(e => e.Ticket)
                .ThenInclude(e => e.TicketAccounts)
                .Include(e => e.EventCharacters)
                .Include(e => e.EventImages)
                .Include(e => e.EventActivities)
                .ThenInclude(e => e.Activity)
                .FirstOrDefaultAsync(e => e.EventId == id);
        }


        public async Task<bool> AddEvent(Event eventObj)
        {
            await _dbContext.Events.AddAsync(eventObj);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateEvent(Event eventObj)
        {
            _dbContext.Events.Update(eventObj);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteEvent(string id)
        {
            var eventObj = await GetEventById(id);
            if (eventObj != null)
            {
                eventObj.IsActive = false; // 🔥 Thay vì xóa, chỉ cập nhật IsActive thành false
                eventObj.UpdateDate = DateTime.Now; // ✅ Cập nhật ngày chỉnh sửa gần nhất

                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteEventCharactersByEventId(string eventId)
        {
            var eventCharacters = _dbContext.EventCharacters.Where(ec => ec.EventId == eventId).ToList();

            if (eventCharacters.Any()) // Kiểm tra xem có EventCharacter nào không
            {
                _dbContext.EventCharacters.RemoveRange(eventCharacters);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0; // Trả về true nếu có bản ghi bị xóa
            }

            return false; // Không có EventCharacter nào để xóa
        }
        public async Task<bool> DeleteEventActivityByEventId(string eventId)
        {
            var eventActivitys = _dbContext.EventActivities.Where(ec => ec.EventId == eventId).ToList();

            if (eventActivitys.Any()) // Kiểm tra xem có EventActivity nào không
            {
                _dbContext.EventActivities.RemoveRange(eventActivitys);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0; // Trả về true nếu có bản ghi bị xóa
            }

            return false; // Không có EventActivity nào để xóa
        }
        public async Task<bool> DeleteTicketByEventId(string eventId)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.EventId == eventId);

            if (ticket != null) // Kiểm tra nếu có Ticket liên kết với EventId
            {
                _dbContext.Tickets.Remove(ticket);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0; // Trả về true nếu Ticket đã bị xóa
            }

            return false; // Không tìm thấy Ticket để xóa
        }

        public Task<Event> GetEventByEventId(string id)
        {
            return _dbContext.Events.Include(e => e.EventCharacters).FirstOrDefaultAsync(e => e.EventId.Equals(id)); 
        }
        public async Task<bool> DeleteTicketsByEventId(string eventId)
        {
            var tickets = await _dbContext.Tickets.Where(t => t.EventId == eventId).ToListAsync();

            if (tickets.Any())
            {
                _dbContext.Tickets.RemoveRange(tickets);
                await _dbContext.SaveChangesAsync();
                return true; // Thành công
            }

            return false; // Không tìm thấy ticket nào
        }

        public async Task<bool> DeleteEventImageById(string id)
        {
            var image = await _dbContext.EventImages.FirstOrDefaultAsync(i => i.ImageId == id);

            if (image == null)
            {
                return false;
            }

            _dbContext.EventImages.Remove(image);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CheckEventValid(string eventId, DateTime start, DateTime end)
        {
            Event request = await _dbContext.Events.FirstOrDefaultAsync(r => r.EventId.Equals(eventId));

            if (request.StartDate.Date < start.Date)
            {
                if (start.Date < request.EndDate.Date && request.EndDate.Date < end.Date)
                {
                    return false;
                }

                if (request.EndDate.Date == end.Date)
                {
                    return false;
                }

                if (request.EndDate.Date > end.Date)
                {
                    return false;
                }

                if (request.EndDate.Date == start.Date)
                {
                    return false;
                }
            }

            if (start.Date < request.StartDate.Date)
            {
                if (request.StartDate.Date < end.Date)
                {
                    return false;
                }

                if (request.StartDate.Date == end.Date)
                {
                    return false;
                }
            }

            if (start.Date == request.StartDate.Date)
            {
                return false;
            }

            return true;
        }

    }
}
