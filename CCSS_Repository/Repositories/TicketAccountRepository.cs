using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ITicketAccountRepository
    {
        Task<TicketAccount> GetTicketAccount(string id);
        Task<TicketAccount> GetTicketAccountByTicketCode(string ticketCode);
        Task<List<TicketAccount>> GetTicketAccountByAccountId(string id);
        Task<List<TicketAccount>> GetAllTicketAccounts();
        Task<bool> AddTicketAccount(TicketAccount ticketAccount);
        Task<bool> UpdateTicketAccount(TicketAccount ticketAccount);
        Task<bool> DeleteTicketAccount(string id);
    }

    public class TicketAccountRepository : ITicketAccountRepository
    {
        private readonly CCSSDbContext _dbContext;

        public TicketAccountRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketAccount> GetTicketAccount(string id)
        {
            return await _dbContext.TicketAccounts
                .Where(ta => ta.TicketAccountId == id && ta.Ticket.Event.IsActive == true) 
                .Include(ta => ta.Ticket) 
                .ThenInclude(t => t.Event) 
                .FirstOrDefaultAsync();
        }
        public async Task<List<TicketAccount>> GetTicketAccountByAccountId(string id)
        {
            return await _dbContext.TicketAccounts
                .Where(ta => ta.AccountId == id && ta.Ticket.Event.IsActive == true) 
                .Include(ta => ta.Ticket) 
                .ThenInclude(t => t.Event) 
                .ToListAsync();
        }
        public async Task<TicketAccount> GetTicketAccountByTicketCode(string ticketCode)
        {
            return await _dbContext.TicketAccounts
                .Where(ta => ta.TicketCode == ticketCode) 
                .FirstOrDefaultAsync();
        }
        public async Task<List<TicketAccount>> GetAllTicketAccounts()
        {
            return await _dbContext.TicketAccounts
                .Where(ta => ta.Ticket.Event.IsActive == true) 
                .Include(ta => ta.Ticket) 
                .ThenInclude(t => t.Event) 
                .ToListAsync();
        }


        public async Task<bool> AddTicketAccount(TicketAccount ticketAccount)
        {
            await _dbContext.AddAsync(ticketAccount);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateTicketAccount(TicketAccount ticketAccount)
        {
            _dbContext.Update(ticketAccount);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteTicketAccount(string id)
        {
            var ticketAccount = await _dbContext.TicketAccounts.FirstOrDefaultAsync(ta => ta.TicketAccountId == id);

            if (ticketAccount == null)
            {
                return false; // Trả về false nếu không tìm thấy TicketAccount
            }

            _dbContext.TicketAccounts.Remove(ticketAccount);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        
    }
}
