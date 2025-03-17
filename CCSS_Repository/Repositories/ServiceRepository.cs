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
    }
    public class ServiceRepository : IServiceRepository
    {
        private readonly CCSSDbContext dbContext;
        public ServiceRepository(CCSSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Service> GetService(string id)
        {
            return await dbContext.Services.FirstOrDefaultAsync(s => s.ServiceId.Equals(id));    
        }
    }
}
