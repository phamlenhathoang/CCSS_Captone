using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICustomerCharacterRepository
    {
        Task<bool> AddCustomerCharacterRepository(CustomerCharacter customerCharacter);
    }
    public class CustomerCharacterRepository : ICustomerCharacterRepository
    {
        private readonly CCSSDbContext _context;

        public CustomerCharacterRepository(CCSSDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCustomerCharacterRepository(CustomerCharacter customerCharacter)
        {
            await _context.AddAsync(customerCharacter);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
