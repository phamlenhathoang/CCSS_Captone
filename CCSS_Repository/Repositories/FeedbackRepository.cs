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
        Task<bool> UpdateFeedback(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacksByCosplayerId(string cosplayerId);
        Task<Feedback> GetFeedbackByFeedbackId(string feedbackId);
        Task<Feedback> GetFeedbackByContractCharacterId(string contractCharacterId);
        Task<List<Feedback>> GetAllFeedback();
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
            try
            {
                await _dbContext.AddAsync(feedback);
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddListFeedback(List<Feedback> feedbacks)
        {
            await _dbContext.AddRangeAsync(feedbacks);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<Feedback>> GetAllFeedback()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> GetAllFeedbacksByCosplayerId(string cosplayerId)
        {
            return await _dbContext.Feedbacks.Include(a => a.Account).Where(f => f.AccountId.Equals(cosplayerId)).ToListAsync();
        }

        public async Task<Feedback> GetFeedbackByContractCharacterId(string contractCharacterId)
        {
            return await _dbContext.Feedbacks.FirstOrDefaultAsync(f => f.ContractCharacterId.Equals(contractCharacterId));
        }

        public async Task<Feedback> GetFeedbackByFeedbackId(string feedbackId)
        {
            return await _dbContext.Feedbacks.Include(a => a.Account).FirstOrDefaultAsync(f => f.FeedbackId.Equals(feedbackId));
        }

        public async Task<bool> UpdateFeedback(Feedback feedback)
        {
            _dbContext.Feedbacks.Update(feedback);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
