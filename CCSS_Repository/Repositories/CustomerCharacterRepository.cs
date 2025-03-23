using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICustomerCharacterRepository
    {
        Task<bool> AddCustomerCharacter(CustomerCharacter customerCharacter);
        Task<CustomerCharacter> GetCustomerCharacterByIdAndCustomerId(string id, string accountId);
        Task<CustomerCharacter> GetCustomerCharacterById(string id);
        Task<List<CustomerCharacter>> GetCustomerCharacters(string? customerCharacterId, string? accountId, string? categoryId, string? createDate, string? status);
        Task<bool> UpdateCustomerCharacter(CustomerCharacter customerCharacter);
    }
    public class CustomerCharacterRepository : ICustomerCharacterRepository
    {
        private readonly CCSSDbContext _context;

        public CustomerCharacterRepository(CCSSDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCustomerCharacter(CustomerCharacter customerCharacter)
        {
            await _context.AddAsync(customerCharacter);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<CustomerCharacter> GetCustomerCharacterById(string id)
        {
            return await _context.CustomerCharacters.Include(c => c.CustomerCharacterImages).FirstOrDefaultAsync(c => c.CustomerCharacterId.Equals(id));
        }

        public async Task<CustomerCharacter> GetCustomerCharacterByIdAndCustomerId(string id, string accountId)
        {
            return await _context.CustomerCharacters.Include(c => c.CustomerCharacterImages).FirstOrDefaultAsync(c => c.CustomerCharacterId.Equals(id) && c.CreateBy.Equals(accountId));
        }

        public async Task<List<CustomerCharacter>> GetCustomerCharacters(string? customerCharacterId, string? accountId, string? categoryId, string? createDate, string? status)
        {
            IQueryable<CustomerCharacter> query = _context.CustomerCharacters.Include(ci => ci.CustomerCharacterImages);
            if (!string.IsNullOrEmpty(customerCharacterId))
            {
                query = query.Where(cc => cc.CustomerCharacterId.Equals(customerCharacterId));
            }

            if (!string.IsNullOrEmpty(accountId))
            {
                query = query.Where(cc => cc.CreateBy.Equals(accountId));
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                query = query.Where(cc => cc.CategoryId.Equals(categoryId));    
            }

            if (!string.IsNullOrEmpty(createDate))
            {
                DateTime createDateTime = DateTime.ParseExact(createDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(cc => cc.CreateDate.Date == createDateTime);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(cc => cc.Status.ToString().ToLower().Equals(status.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateCustomerCharacter(CustomerCharacter customerCharacter)
        {
            _context.CustomerCharacters.Update(customerCharacter);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
