using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICustomerCharacterImageRepository
    {
        Task<bool> AddListCustomerCharacterImage(List<CustomerCharacterImage> customerCharacterImages);
    }
    public class CustomerCharacterImageRepository : ICustomerCharacterImageRepository
    {
        private readonly CCSSDbContext _context;
        public CustomerCharacterImageRepository(CCSSDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddListCustomerCharacterImage(List<CustomerCharacterImage> customerCharacterImages)
        {
            await _context.AddRangeAsync(customerCharacterImages);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
