using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Repository.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountByCategoryId(string categoryId, string? accountId);
        Task<Account> GetAccount(string accountId);
        Task<List<Account>> GetAllAccountOrganizer();
        Task<Account> GetAccountIncludeAccountCategory(string accountId);
        Task<Account> GetAccountByAccountId(string accountId);
        Task<Account> GetAccountByAccountIdIncludeTask(string acountId, string? taskId);
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
            return await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId && x.Leader == true && x.IsActive == true);   
        }

        public async Task<Account> GetAccountByAccountId(string accountId)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId && a.IsActive == true); 
        }

        public async Task<Account> GetAccountByAccountIdIncludeTask(string acountId, string? taskId)
        {
            IQueryable<Account> account = dbContext.Accounts.Include(a => a.Tasks).Where(a => a.AccountId == acountId && a.IsActive == true);
            
            if (!string.IsNullOrEmpty(taskId))
            {
                account = account.Where(a => a.Tasks.Any(t => t.TaskId == taskId && t.IsActive == true));
            }

            return await account.FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAccountByCategoryId(string categoryId, string? accountId)
        {
            IQueryable<Account> accounts = dbContext.Accounts
                .Include(x => x.AccountCategories)
                .Include(x => x.Role)
                .Where(x => x.AccountCategories.Any(ac => ac.CategoryId == categoryId))
                .Where(x => x.Role.RoleName == RoleName.Cosplayer && x.IsActive == true)
                .OrderBy(x => x.TaskQuantity);

            if (!accountId.IsNullOrEmpty())
            {
                accounts = accounts.Where(a => !a.AccountId.Equals(accountId));
            }

            return await accounts.ToListAsync();
        }

        public async Task<Account> GetAccountIncludeAccountCategory(string accountId)
        {
            return await dbContext.Accounts.Include(a => a.AccountCategories).FirstOrDefaultAsync(x => x.AccountId == accountId && x.IsActive == true);
        }

        public async Task<List<Account>> GetAllAccountOrganizer()
        {
            return await dbContext.Accounts.Include(a => a.Role).Where(a => a.Role.RoleName == RoleName.Organizer && a.IsActive == true).OrderBy(a => a.TaskQuantity).ToListAsync();
        }
    }
}
