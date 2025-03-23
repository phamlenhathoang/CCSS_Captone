using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
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
        Task<bool> UpdateCustomerCharacterImage(CustomerCharacterImage customerCharacterImages);
        Task<CustomerCharacterImage> GetCustomerCharacterImage(string id);
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

        public async Task<CustomerCharacterImage> GetCustomerCharacterImage(string id)
        {
            return await _context.CustomerCharacterImages.FirstOrDefaultAsync(c => c.CustomerCharacterId.Equals(id));
        }

        public async Task<bool> UpdateCustomerCharacterImage(CustomerCharacterImage customerCharacterImages)
        {
            _context.CustomerCharacterImages.Update(customerCharacterImages);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
