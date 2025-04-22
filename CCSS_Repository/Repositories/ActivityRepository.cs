using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetActivityById(string activityId);
        Task<bool> AddActivity(Activity activity);
        Task<bool> UpdateActivity(Activity activity);
        Task<bool> DeleteActivity(Activity activity);
    }
    public class ActivityRepository : IActivityRepository
    {
        private readonly CCSSDbContext _context;

        public ActivityRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            return await _context.Activities
                                 .Include(a => a.EventActivities)
                                 .ToListAsync();
        }

        public async Task<Activity> GetActivityById(string activityId)
        {
            return await _context.Activities
                                 .Include(a => a.EventActivities)
                                 .FirstOrDefaultAsync(a => a.ActivityId == activityId);
        }

        public async Task<bool> AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteActivity(Activity activity)
        {
            _context.Activities.Remove(activity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
