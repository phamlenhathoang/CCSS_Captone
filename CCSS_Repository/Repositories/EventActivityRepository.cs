using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CCSS_Repository.Entities;

public interface IEventActivityRepository
{
    Task<EventActivity> GetEventActivity(string id);
    Task<List<EventActivity>> GetAllEventActivities();
    Task<bool> AddEventActivity(EventActivity eventActivity);
    Task<bool> UpdateEventActivity(EventActivity eventActivity);
    Task<bool> DeleteEventActivity(EventActivity eventActivity);
}

public class EventActivityRepository : IEventActivityRepository
{
    private readonly CCSSDbContext _dbContext;

    public EventActivityRepository(CCSSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EventActivity> GetEventActivity(string id)
    {
        return await _dbContext.EventActivities
            .Where(ea => ea.EventActivityId == id) 
            .FirstOrDefaultAsync();
    }

    public async Task<List<EventActivity>> GetAllEventActivities()
    {
        return await _dbContext.EventActivities
            .Where(ea => ea.Event.IsActive == true)
            .Include(ea => ea.Event)
            .ToListAsync();
    }

    public async Task<bool> AddEventActivity(EventActivity eventActivity)
    {
        await _dbContext.EventActivities.AddAsync(eventActivity);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateEventActivity(EventActivity eventActivity)
    {
        _dbContext.EventActivities.Update(eventActivity);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteEventActivity(EventActivity eventActivity)
    {
        _dbContext.EventActivities.Remove(eventActivity);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}