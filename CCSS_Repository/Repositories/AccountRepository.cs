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
        public Task<Account> GetAccount(string email, string password)
        {
            return _dbContext.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }
    }
}
