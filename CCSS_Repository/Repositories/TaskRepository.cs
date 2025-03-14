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
        //Task<Task> GetTask(string id);
        //Task<List<Task>> GetTaskByAccountId(string accountId);
        Task<bool> AddTask(CCSS_Repository.Entities.Task tasks);
        //Task<bool> AddRangeTask(List<Task> task);
        //Task<bool> UpdateTask(CCSS_Repository.Entities.Task task);
        //Task<bool> DeleteTask(CCSS_Repository.Entities.Task task);
        //Task<List<Task>> GetTaskByAccountId(string accountId, string? taskId);
        //Task<List<Task>> GetTaslByContractId(string contractId);
        Task<List<Task>> GetAllTask();

        Task<bool> CheckTaskIsValid(Account account, DateTime startDate, DateTime endDate);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly CCSSDbContext _dbContext;

        public TaskRepository(CCSSDbContext cCSSDbContext)
        {
            _dbContext = cCSSDbContext;
        }

        //public async Task<bool> AddRangeTask(List<Task> tasks)
        //{
        //    await _dbContext.Tasks.AddRangeAsync(tasks);
        //    int result = await _dbContext.SaveChangesAsync();
        //    return result > 0 ? true : false;
        //}

        public async Task<bool> AddTask(Entities.Task task)
        {
            await _dbContext.AddAsync(task);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<List<Task>> GetAllTask()
        {
            return await _dbContext.Tasks.Where(t => t.IsActive == true).ToListAsync();    
        }

        public async Task<bool> CheckTaskIsValid(Account account, DateTime startDate, DateTime endDate)
        {
            //if (startDate.Date == endDate.Date)
            //{
            //    double totalInHour = 0;
            //    var checkTasks = await _dbContext.Tasks.Where(a => a.AccountId.Equals(account.AccountId) 
            //    && a.StartDate.HasValue && a.StartDate.Value.Date == startDate.Date 
            //    && a.EndDate.HasValue && a.EndDate.Value.Date == startDate.Date).ToListAsync();
            //    if (checkTasks.Any())
            //    {
            //        foreach (var task in checkTasks)
            //        {
            //            totalInHour += (task.EndDate.GetValueOrDefault() - task.StartDate.GetValueOrDefault()).TotalHours;
            //        }
            //    }

            //    totalInHour += (endDate - startDate).TotalHours;

            //    if (totalInHour > 8)
            //    {
            //        return false;
            //    }
            //}

            DateTime rangeStart = startDate.AddDays(-7);

            var tasks = await _dbContext.Tasks
                .Where(t => t.AccountId == account.AccountId
                       && t.StartDate >= rangeStart && t.IsActive == true)
                .OrderBy(t => t.StartDate)
                .ToListAsync();

            if (!tasks.Any())
            {
                return true;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                var currentTask = tasks[i];

                if (endDate.AddHours(2) > currentTask.StartDate.GetValueOrDefault())
                {
                    return false; // Task trước chưa nghỉ đủ 2 giờ
                }

                if (currentTask.EndDate.GetValueOrDefault() > startDate.AddHours(-2))
                {
                    return false; // Task trước chưa nghỉ đủ 2 giờ
                }

                //if (currentTask.StartDate.GetValueOrDefault().Date == startDate.Date && startDate.Date == endDate.Date)
                //{

                //    if (startDate.Date > currentTask.EndDate.GetValueOrDefault().AddHours(2).Date)
                //    {
                //        return false;
                //    }

                //    if (endDate.Date > currentTask.StartDate.GetValueOrDefault().AddHours(2).Date)
                //    {
                //        return false;
                //    }
                //}

                if (i > 0)
                {
                    var previousTask = tasks[i - 1];

                    if (startDate < previousTask.EndDate.GetValueOrDefault().AddHours(2))
                    {
                        return false; // Task trước chưa nghỉ đủ 2 giờ
                    }

                    // Kiểm tra tổng giờ làm nếu cùng ngày
                    //if (startDate.Date == previousTask.StartDate.GetValueOrDefault().Date && startDate.Date == previousTask.EndDate.GetValueOrDefault().Date)
                    //{
                    //    totalHoursInDay = (previousTask.EndDate.GetValueOrDefault() - previousTask.StartDate.GetValueOrDefault()).TotalHours;
                    //}
                }


                if (i < tasks.Count - 1)
                {
                    var nextTask = tasks[i + 1];

                    if (endDate > nextTask.StartDate.GetValueOrDefault().AddHours(-2))
                    {
                        return false; // Task sau chưa chuẩn bị đủ 2 giờ
                    }

                    // Kiểm tra tổng giờ làm nếu cùng ngày
                    //if (startDate.Date == nextTask.EndDate.GetValueOrDefault().Date && startDate.Date == nextTask.StartDate.GetValueOrDefault().Date)
                    //{
                    //    totalHoursInDay = (nextTask.EndDate.GetValueOrDefault() - nextTask.StartDate.GetValueOrDefault()).TotalHours;

                    //}
                }

                //if (totalHoursInDay > 8)
                //{
                //    return false;
                //}
            }

            return true;

        }

        //public async Task<bool> DeleteTask(CCSS_Repository.Entities.Task task)
        //{
        //    _dbContext.Remove(task);
        //    int result = await _dbContext.SaveChangesAsync();
        //    return result > 0 ? true : false;
        //}

        //public async Task<Entities.Task> GetTask(string id)
        //{
        //    return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == id && t.IsActive == true);
        //}

        //public async Task<List<Task>> GetTaskByAccountId(string accountId)
        //{
        //    return await _dbContext.Tasks.Where(t => t.AccountId == accountId && t.IsActive == true).OrderBy(t => t.StartDate).ToListAsync();    
        //}

        //public async Task<bool> UpdateTask(Entities.Task task)
        //{
        //    _dbContext.Update(task);
        //    int result = await _dbContext.SaveChangesAsync();
        //    return result > 0 ? true : false;
        //}

        //public async Task<List<Task>> GetTaskByAccountId(string accountId, string? taskId)
        //{
        //    IQueryable<Task> tasks =  _dbContext.Tasks.Include(t => t.Account).Where(t => t.AccountId == accountId && t.IsActive == true);
        //    if (!string.IsNullOrEmpty(taskId))
        //    {
        //        tasks = tasks.Where(t => t.TaskId == taskId);
        //    }
        //    return await tasks.ToListAsync();
        //}

        //public async Task<List<Task>> GetTaslByContractId(string contractId)
        //{
        //    return await _dbContext.Tasks.Where(t => t.ContractId.Equals(contractId)).ToListAsync();
        //}
    }
}
