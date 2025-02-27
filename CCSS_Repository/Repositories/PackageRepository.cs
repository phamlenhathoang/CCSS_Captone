using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IPackageRepository
    {
        Task<Package> GetPackage(string packageId);
        Task<List<Package>> GetAll();
        Task<bool> AddPackage(Package package);
        Task<bool> UpdatePackage(Package package);
        Task<bool> DeletePackage(Package package);

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
            return await _context.Packages.FirstOrDefaultAsync(p => p.PackageId.Equals(packageId));
        }

        public async Task<bool> AddPackage(Package package)
        {
            _context.Packages.Add(package);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePackage(Package package)
        {
            _context.Packages.Update(package);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePackage(Package package)
        {
            _context.Packages.Remove(package);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
