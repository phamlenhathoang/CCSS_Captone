using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IFeedbackRepository
    {
        Task<bool> AddListFeedback(List<Feedback> feedbacks);
        Task<bool> AddFeedback(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacksByCosplayerId(string cosplayerId);
    }
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly CCSSDbContext _dbContext;

        public FeedbackRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            await _dbContext.AddAsync(feedback);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> AddListFeedback(List<Feedback> feedbacks)
        {
            await _dbContext.AddRangeAsync(feedbacks);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<Feedback>> GetAllFeedbacksByCosplayerId(string cosplayerId)
        {
            return await _dbContext.Feedbacks.Where(f => f.AccountId.Equals(cosplayerId)).ToListAsync();
        }
    }
}
