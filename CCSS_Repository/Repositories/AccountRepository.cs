using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountByCategoryId(string categoryId, int quantity, DateTime startDate, DateTime endDate);
        Task<Account> GetAccount(string accountId);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly CCSSDbContext dbContext;
        public AccountRepository(CCSSDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Account> GetAccount(string accountId)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId && x.Leader == true);   
        }

        public async Task<List<Account>?> GetAccountByCategoryId(string categoryId, int quantity, DateTime startDate, DateTime endDate)
        {
            var accounts = await dbContext.AccountCategories
                .Where(ac => ac.CategoryId == categoryId)
                .Join(dbContext.Accounts,
                      ac => ac.AccountId,
                      a => a.AccountId,
                      (ac, a) => a)
                .Where(a => dbContext.Tasks.Any(t =>
                            t.AccountId == a.AccountId &&
                            (t.StartDate != startDate || t.EndDate != endDate))) 
                .OrderBy(a => a.TaskQuantity) 
                .Take(quantity) 
                .ToListAsync();

            return accounts.Count == quantity ? accounts : null; // Nếu không đủ số lượng thì trả về null
        }

    }
}
