using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IPackageRepository
    {
        Task<Package> GetPackage(string packageId);
        Task<List<Package>> GetAll();
    }
    public class PackageRepository : IPackageRepository
    {
        private readonly CCSSDbContext _context;
        public PackageRepository(CCSSDbContext cCSSDbContext) 
        {
            _context = cCSSDbContext;
        }

        public async Task<List<Package>> GetAll()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetPackage(string packageId)
        {
            return await _context.Packages.FirstOrDefaultAsync(p => p.PackageId == packageId);
        }
    }
}
