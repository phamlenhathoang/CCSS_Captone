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
        //Task<List<Account>> GetAccountByCategoryId(string categoryId, string? accountId);
        Task<Account> GetAccount(string accountId);
        //Task<List<Account>> GetAllAccountLeader();
        //Task<Account> GetAccountIncludeAccountCategory(string accountId);
        Task<Account> GetAccountByAccountId(string accountId);
        //Task<Account> GetAccountByAccountIdIncludeTask(string acountId, string? taskId);
        Task<Account> GetAccountByEmailAndPassword(string email, string password);
        Task<Account> GetAccountByEmail(string email);
        Task<Account> GetAccountByEmailAndCode(string email, string code);
        Task<bool> AddAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<List<Account>> GetAllAccountsByCharacter(Character character);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly CCSSDbContext dbContext;
        public AccountRepository(CCSSDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAccount(Account account)
        {
            await dbContext.AddAsync(account);
            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Account> GetAccount(string accountId)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId && x.IsActive == true);   
        }

        public async Task<Account> GetAccountByAccountId(string accountId)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId && a.IsActive == true); 
        }

        //public async Task<Account> GetAccountByAccountIdIncludeTask(string acountId, string? taskId)
        //{
        //    IQueryable<Account> account = dbContext.Accounts.Include(a => a.Tasks).Where(a => a.AccountId == acountId && a.IsActive == true);
            
        //    if (!string.IsNullOrEmpty(taskId))
        //    {
        //        account = account.Where(a => a.Tasks.Any(t => t.TaskId == taskId && t.IsActive == true));
        //    }

        //    return await account.FirstOrDefaultAsync();
        //}

        //public async Task<List<Account>> GetAccountByCategoryId(string categoryId, string? accountId)
        //{
        //    IQueryable<Account> accounts = dbContext.Accounts
        //        .Include(x => x.AccountCategories)
        //        .Include(x => x.Role)
        //        .Where(x => x.AccountCategories.Any(ac => ac.CategoryId == categoryId))
        //        .Where(x => x.Role.RoleName == RoleName.Cosplayer && x.IsActive == true)
        //        .OrderBy(x => x.TaskQuantity);

        //    if (!string.IsNullOrEmpty(accountId))
        //    {
        //        accounts = accounts.Where(a => !a.AccountId.Equals(accountId));
        //    }

        //    return await accounts.ToListAsync();
        //}

        public Task<Account> GetAccountByEmail(string email)
        {
            return dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == email);   
        }

        public Task<Account> GetAccountByEmailAndCode(string email, string code)
        {
            return dbContext.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email) && a.Code.Equals(code));
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            return await dbContext.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Email == email && a.Password == password);   
        }

        public async Task<List<Account>> GetAllAccountsByCharacter(Character character)
        {
            return await dbContext.Accounts.Where(a => character.MinHeight < a.Height && a.Height < character.MaxHeight
                                                        && character.MinWeight < a.Weight && a.Weight < character.MaxHeight).ToListAsync();
        }

        //public async Task<Account> GetAccountIncludeAccountCategory(string accountId)
        //{
        //    return await dbContext.Accounts.Include(a => a.AccountCategories).FirstOrDefaultAsync(x => x.AccountId == accountId && x.IsActive == true);
        //}

        //public async Task<List<Account>> GetAllAccountLeader()
        //{
        //    return await dbContext.Accounts.Include(a => a.Role).Where(a => a.Leader == true && a.IsActive == true).OrderBy(a => a.TaskQuantity).ToListAsync();
        //}

        public async Task<bool> UpdateAccount(Account account)
        {
            dbContext.Update(account);
            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
