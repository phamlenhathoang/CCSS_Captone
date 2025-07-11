﻿using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

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
        Task<Account> GetAccountByEventCharacterId(string id);
        Task<Account> GetAccountByEmailAndCode(string email, string code);
        Task<bool> AddAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<List<Account>> GetAllAccountsByCharacter(Character character, string? accountId);
        Task<List<Account>> GetAllAccountsByCharacter(Character character, int minSalary, int maxSalary);
        Task<List<Account>> GetAccountsByCharacter(Character character, List<Account> accounts);
        Task<List<Account>> GetAllAccountsByRoleId(string roleId);
        Task<List<Account>> GetAllAccountRoleManager();
        Task<Account> GetAccountByUsername(string username);
        Task<Account> GetAccountByGoogleId(string email, string googleId);
        Task AddAccountGoogle(Account account);
        Task<List<Account>> GetAllAccount(string? searchterm, string roleId);
        Task<Account> GetAccountByAccountIdNotActive(string accountId);
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
            try
            {
                await dbContext.AddAsync(account);
                return await dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
        public async Task AddAccountGoogle(Account account)
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAllAccount(string? searchterm, string roleId)
        {
            if (string.IsNullOrEmpty(searchterm))
            {
                return await dbContext.Accounts.Include(ac => ac.AccountImages).Where(sc => sc.RoleId.Equals(roleId)).ToListAsync();
            }
            return await dbContext.Accounts.Include(ac => ac.AccountImages).Where(sc => sc.Name.Equals(searchterm) && sc.RoleId.Equals(roleId)).ToListAsync();
        }
        public async Task<Account> GetAccountByGoogleId(string email, string googleId)
        {
            return await dbContext.Accounts.Include(sc => sc.Role).FirstOrDefaultAsync(sc => sc.Email.Equals(email) && sc.GoogleId.Equals(googleId));
        }
        public async Task<Account> GetAccountByEventCharacterId(string eventCharacterId)
        {
            return await dbContext.Accounts
                .Include(a => a.AccountImages) 
                .Include(a => a.Tasks) 
                    .ThenInclude(t => t.EventCharacter) 
                .FirstOrDefaultAsync(a => a.Tasks.Any(t => t.EventCharacter.EventCharacterId == eventCharacterId) && a.IsActive == true);
        }

        public async Task<Account> GetAccount(string accountId)
        {
            return await dbContext.Accounts.Include(r => r.Role).Include(a => a.AccountImages).Include(a => a.Tasks).FirstOrDefaultAsync(x => x.AccountId == accountId && x.IsActive == true);
        }

        public async Task<Account> GetAccountByAccountId(string accountId)
        {
            return await dbContext.Accounts.Include(a => a.AccountImages).FirstOrDefaultAsync(a => a.AccountId == accountId && a.IsActive == true);
        }

        public async Task<Account> GetAccountByAccountIdNotActive(string accountId)
        {
            return await dbContext.Accounts.Include(a => a.AccountImages).FirstOrDefaultAsync(a => a.AccountId == accountId);
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
            return await dbContext.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Email == email && a.Password == password && a.IsActive == true);
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await dbContext.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.UserName.Equals(username) && a.IsActive == true && a.Role.RoleName == RoleName.Cosplayer);
        }

        public async Task<List<Account>> GetAllAccountRoleManager()
        {
            return await dbContext.Accounts.Include(r => r.Role).Where(a => a.Role.RoleName == RoleName.Manager && a.IsActive == true).ToListAsync();
        }

        public async Task<List<Account>> GetAllAccountsByCharacter(Character character, string? accountId)
        {
            IQueryable<Account> query = dbContext.Accounts
                .Include(r => r.Role)
                .Include(a => a.AccountImages)
                .Where(a => character.MinHeight <= a.Height && a.Height <= character.MaxHeight && character.MinWeight <= a.Weight && a.Weight <= character.MaxHeight && a.Role.RoleName == RoleName.Cosplayer && a.IsLock == false && a.IsActive == true);
            if (!string.IsNullOrEmpty(accountId))
            {
                query = query.Where(a => !a.AccountId.Equals(accountId));
            }

            return await query.OrderByDescending(a => a.AverageStar).ToListAsync();
        }

        public async Task<List<Account>> GetAllAccountsByRoleId(string roleId)
        {
            return await dbContext.Accounts.Include(r => r.Role).Include(ai => ai.AccountImages).Where(a => a.RoleId.Equals(roleId) && a.IsActive == true).ToListAsync();
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
            try
            {
                dbContext.Accounts.Update(account);
                return await dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Account>> GetAccountsByCharacter(Character character, List<Account> accounts)
        {
            IQueryable<Account> query = dbContext.Accounts;
            if (accounts.Any())
            {
                foreach (Account account in accounts)
                {
                    query = query.Where(a => !a.AccountId.Equals(account.AccountId) && a.IsActive == true);
                }
            }

            return await query.ToListAsync();
        }

        public Task<List<Account>> GetAllAccountsByCharacter(Character character, int minSalary, int maxSalary)
        {
            return dbContext.Accounts
                .Include(r => r.Role)
                .Include(a => a.AccountImages)
                .Where(a => character.MinHeight <= a.Height && a.Height <= character.MaxHeight && character.MinWeight <= a.Weight && a.Weight <= character.MaxHeight && a.Role.RoleName == RoleName.Cosplayer && a.IsLock == false && a.IsActive == true && minSalary <= a.SalaryIndex && a.SalaryIndex <= maxSalary).OrderBy(a => a.SalaryIndex).ToListAsync();
        }
    }
}
