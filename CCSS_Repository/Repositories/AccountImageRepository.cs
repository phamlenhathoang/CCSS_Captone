using CCSS_Repository.Entities;
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
    }
}
