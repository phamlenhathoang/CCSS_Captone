using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ITaskRepository
    {
        Task<CCSS_Repository.Entities.Task> GetTask(string id);
        Task<bool> AddTask(CCSS_Repository.Entities.Task task);
        Task<bool> UpdateTask(CCSS_Repository.Entities.Task task);
        Task<bool> DeleteTask(CCSS_Repository.Entities.Task task);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly CCSSDbContext _dbContext;

        public TaskRepository(CCSSDbContext cCSSDbContext)
        {
            _dbContext = cCSSDbContext;
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
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<bool> UpdateTask(Entities.Task task)
        {
            _dbContext.Update(task);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}
