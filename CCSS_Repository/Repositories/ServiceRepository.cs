using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> GetService(string id);
        Task<List<Service>> GetAllService();
    }
    public class ServiceRepository : IServiceRepository
    {
        private readonly CCSSDbContext _context;
        public ServiceRepository(CCSSDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task<Service> GetService(string id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.ServiceId.Equals(id));    
        }

        public async Task<List<Service>> GetAllService()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
