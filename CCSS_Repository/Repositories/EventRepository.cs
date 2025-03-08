using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents(string searchTerm);
        Task<Event> GetEventById(string id);
        Task<Event> GetEventByTicketId(string ticketId);
        Task<bool> AddEvent(Event eventObj);
        Task<bool> UpdateEvent(Event eventObj);
        Task<bool> DeleteEvent(string id);
        Task<bool> DeleteEventCharactersByEventId(string id);
        Task<bool> DeleteTicketByEventId(string id);
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
        public async Task<List<Event>> GetAllEvents(string searchTerm)
        {
            var query = _dbContext.Events
                .Where(e => e.IsActive == true) // 🔥 Chỉ lấy sự kiện có IsActive == true
                .AsQueryable();

            // Nếu có searchTerm, lọc trước khi Include để tối ưu truy vấn
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(e => e.EventName.Contains(searchTerm));
            }

            // Luôn Include Ticket & EventCharacters sau khi lọc
            query = query
                .Include(e => e.Ticket)
                .Include(e => e.EventCharacters)
                .Include(e => e.Images);

            return await query.ToListAsync();
        }
        public async Task<Event> GetEventByTicketId(string ticketId)
        {
            return await _dbContext.Events
        .Where(e => e.IsActive == true && e.Ticket.TicketId == ticketId) 
        .Include(e => e.Ticket) 
        .FirstOrDefaultAsync();
        }



        public async Task<Event> GetEventById(string id)
        {
            return await _dbContext.Events
                .Where(e => e.IsActive == true) // 🔥 Chỉ lấy sự kiện có IsActive == true
                .Include(e => e.Ticket)
                .Include(e => e.EventCharacters)
                .Include(e => e.Images)
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

    }
}
