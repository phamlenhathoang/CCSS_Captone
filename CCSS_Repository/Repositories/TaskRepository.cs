using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Repository.Repositories
{
    public interface ITaskRepository
    {
        Task<Task> GetTask(string id);
        Task<List<Task>> GetTaskByAccountId(string accountId);
        Task<bool> AddTask(CCSS_Repository.Entities.Task tasks);
        Task<bool> AddRangeTask(List<Task> task);
        Task<bool> UpdateTask(CCSS_Repository.Entities.Task task);
        Task<bool> DeleteTask(CCSS_Repository.Entities.Task task);
        Task<List<Task>> GetTaskByAccountId(string accountId, string? taskId);
        Task<List<Task>> GetTaslByContractId(string contractId);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly CCSSDbContext _dbContext;

        public TaskRepository(CCSSDbContext cCSSDbContext)
        {
            _dbContext = cCSSDbContext;
        }

        public async Task<bool> AddRangeTask(List<Task> tasks)
        {
            await _dbContext.Tasks.AddRangeAsync(tasks);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> AddTask(Entities.Task task)
        {
            await _dbContext.AddAsync(task);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> DeleteTask(CCSS_Repository.Entities.Task task)
        {
            _dbContext.Remove(task);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<Entities.Task> GetTask(string id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == id && t.IsActive == true);
        }

        public async Task<List<Task>> GetTaskByAccountId(string accountId)
        {
            return await _dbContext.Tasks.Where(t => t.AccountId == accountId && t.IsActive == true).OrderBy(t => t.StartDate).ToListAsync();    
        }

        public async Task<bool> UpdateTask(Entities.Task task)
        {
            _dbContext.Update(task);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<List<Task>> GetTaskByAccountId(string accountId, string? taskId)
        {
            IQueryable<Task> tasks =  _dbContext.Tasks.Include(t => t.Account).Where(t => t.AccountId == accountId && t.IsActive == true);
            if (!taskId.IsNullOrEmpty())
            {
                tasks = tasks.Where(t => t.TaskId == taskId);
            }
            return await tasks.ToListAsync();
        }

        public async Task<List<Task>> GetTaslByContractId(string contractId)
        {
            return await _dbContext.Tasks.Where(t => t.ContractId.Equals(contractId)).ToListAsync();
        }
    }
}
