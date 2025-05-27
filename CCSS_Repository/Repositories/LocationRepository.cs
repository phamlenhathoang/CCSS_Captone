using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(string locationId);
        Task<bool> AddLocation(Location location);
        Task<bool> UpdateLocation(Location location);
        Task<bool> DeleteLocation(Location location);
    }
    public class LocationRepository : ILocationRepository
    {
        private readonly CCSSDbContext _context;

        public LocationRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations
                                 .Include(l => l.Event)
                                 .ToListAsync();
        }

        public async Task<Location> GetLocationById(string locationId)
        {
            return await _context.Locations
                                 .Include(l => l.Event)
                                 .FirstOrDefaultAsync(l => l.LocationId == locationId);
        }

        public async Task<bool> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLocation(Location location)
        {
            _context.Locations.Remove(location);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
