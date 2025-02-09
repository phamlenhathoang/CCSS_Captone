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
        Task<Account> GetAccountByEmailAndPassword(string email, string password);
        Task<Account> GetAccountByEmailAndCode(string email, string code);
        Task<Account> GetAccountByEmail(string email);
        Task<bool> AddAcount(Account acount);    
        Task<bool> UpdateAcount(Account acount);
        Task<Account> GetAccount(string email, string? password = null, string? code = null);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly CCSSDBContext _dbContext;

        public AccountRepository(CCSSDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAcount(Account acount)
        {
            await _dbContext.AddAsync(acount);
            int result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                return false;
            }
            return true;    
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);  
        }

        public async Task<Account> GetAccountByEmailAndCode(string email, string code)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email && x.Code == code);
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            return  await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<bool> UpdateAcount(Account acount)
        {
            _dbContext.Update(acount);
            int result = await _dbContext.SaveChangesAsync();
            if (result != 0) 
            {
                return true;
            }
            return false;
        }

        public async Task<Account> GetAccount(string email, string? password = null, string? code = null)
        {
            var query = _dbContext.Accounts.AsQueryable();

            // Lọc theo email
            query = query.Where(x => x.Email == email);

            // Kiểm tra password nếu có
            if (!string.IsNullOrEmpty(password))
            {
                query = query.Where(x => x.Password == password);
            }

            // Kiểm tra code nếu có
            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.Code == code);
            }

            // Trả về tài khoản đầu tiên tìm được
            return await query.FirstOrDefaultAsync();
        }

    }
}
