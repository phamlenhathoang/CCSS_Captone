using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IAccountImageRepository
    {
        Task<bool> AddListAccountImage (List<AccountImage> accountImages);
        Task<AccountImage> GetAccountImageById (string id);
        Task<List<AccountImage>> GetListAccountImagesByAccountId(string id);
    }
    public class AccountImageRepository : IAccountImageRepository
    {
        private readonly CCSSDbContext _dbContext;

        public AccountImageRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddListAccountImage(List<AccountImage> accountImages)
        {
            await _dbContext.AddRangeAsync(accountImages);  
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<AccountImage> GetAccountImageById(string id)
        {
            return await _dbContext.AccountImages.FirstOrDefaultAsync(ac => ac.AccountImageId.Equals(id));
        }

        public async Task<List<AccountImage>> GetListAccountImagesByAccountId(string id)
        {
            return await _dbContext.AccountImages.Include(a => a.Account).Where(ac => ac.AccountId.Equals(id)).ToListAsync();
        }
    }
}
