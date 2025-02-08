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
        Task<Account> GetAccount(string email, string password);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly CCSSDBContext _dbContext;

        public AccountRepository(CCSSDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Account> GetAccount(string email, string? password = null)
        {
            var query = _dbContext.Accounts.Include(a => a.Role).AsQueryable();

            query = query.Where(a => a.Email == email);

            if (!string.IsNullOrEmpty(password))
            {
                query = query.Where(a => a.Password == password);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
