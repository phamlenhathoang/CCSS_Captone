﻿using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicket(int id);
        Task<bool> AddTicket(Ticket ticket);
        Task<bool> UpdateTicket(Ticket ticket);
        Task<bool> DeleteTicket(Ticket ticket);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly CCSSDbContext _dbContext;

        public TicketRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await _dbContext.Tickets
                .Where(t => t.TicketId == id && t.Event.IsActive == true) // Chỉ lấy Ticket có Event.IsActive == true
                .Include(t => t.Event) // Bao gồm Event để đảm bảo có thể truy cập IsActive
                .FirstOrDefaultAsync();
        }


        public async Task<bool> AddTicket(Ticket ticket)
        {
            await _dbContext.AddAsync(ticket);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            _dbContext.Update(ticket);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteTicket(Ticket ticket)
        {
            _dbContext.Remove(ticket);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
        

    }
}
