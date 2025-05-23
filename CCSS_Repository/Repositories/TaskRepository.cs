using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Repository.Repositories
{
    public interface ITaskRepository
    {
        //Task<Task> GetTask(string id);
        //Task<List<Task>> GetTaskByAccountId(string accountId);
        Task<bool> AddTask(Task task);
        //Task<bool> AddRangeTask(List<Task> task);
        //Task<bool> UpdateTask(CCSS_Repository.Entities.Task task);
        //Task<bool> DeleteTask(CCSS_Repository.Entities.Task task);
        //Task<List<Task>> GetTaskByAccountId(string accountId, string? taskId);
        //Task<List<Task>> GetTaslByContractId(string contractId);
        Task<List<Task>> GetAllTask();

        Task<bool> CheckTaskIsValid(Account account, List<DateRepo> dates);
        Task<Task> GetTaskById(string id, string accountId);
        Task<List<Task>> GetTaskByContractCharacterId(string contractCharacterId);
        Task<Task> GetTaskByTaskId(string id);
        Task<bool> UpdateTask(Task task);
        Task<List<Task>> GetTasksByAccountId(string accountId);
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

        public async Task<bool> AddTask(Task task)
        {
            try
            {
                await _dbContext.AddAsync(task);
                int result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Task>> GetAllTask()
        {
            return await _dbContext.Tasks.Where(t => t.IsActive == true).OrderBy(t => t.StartDate).ToListAsync();    
        }

        public async Task<bool> CheckTaskIsValid(Account account, List<DateRepo> dates)
        {
            foreach (var date in dates)
            {
                DateTime rangeStart = date.StartDate.AddDays(-7);
                double totalHourTask = (date.EndDate - date.StartDate).TotalHours;
                double totalHourInDay = 0;
                var tasks = await _dbContext.Tasks
                    .Where(t => t.AccountId.Equals(account.AccountId)
                            && t.IsActive == true)
                    .OrderBy(t => t.StartDate)
                    .ToListAsync();

                if (!tasks.Any())
                {
                    return true;
                }

                for (int i = 0; i < tasks.Count; i++)
                {
                    var currentTask = tasks[i];

                    if (currentTask.StartDate.GetValueOrDefault().Date < date.StartDate.Date)
                    {
                        if (currentTask.EndDate.GetValueOrDefault() > date.StartDate.AddHours(-2))
                        {
                            return false; // Task trước chưa nghỉ đủ 2 giờ
                        }

                        if (totalHourTask >= 8 && date.StartDate.Date == date.EndDate.Date)
                        {

                            if (currentTask.EndDate.GetValueOrDefault() > date.StartDate.AddHours(-2))
                            {
                                return false; // Task trước chưa nghỉ đủ 2 giờ
                            }

                            if (currentTask.EndDate.GetValueOrDefault().AddDays(1) == date.StartDate.Date)
                            {
                                var nextTask = tasks[i + 1];

                                if (date.EndDate.AddDays(1) > nextTask.StartDate.GetValueOrDefault())
                                {
                                    return false;
                                }

                                if (date.EndDate.AddDays(1).AddHours(2) > nextTask.StartDate.GetValueOrDefault())
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    if (date.StartDate.Date < currentTask.StartDate.GetValueOrDefault().Date)
                    {
                        if (date.EndDate.AddHours(2) > currentTask.StartDate.GetValueOrDefault())
                        {
                            return false; // Task trước chưa nghỉ đủ 2 giờ
                        }
                    }

                    if (currentTask.StartDate.GetValueOrDefault().Date == date.StartDate.Date)
                    {
                        if (currentTask.EndDate.GetValueOrDefault().Hour < date.EndDate.Hour)
                        {
                            if (currentTask.EndDate.GetValueOrDefault().AddHours(2) > date.StartDate)
                            {
                                return false;
                            }
                        }

                        if (date.EndDate.Hour > currentTask.StartDate.GetValueOrDefault().Hour)
                        {
                            if (date.EndDate.AddHours(2) > currentTask.StartDate.GetValueOrDefault())
                            {
                                return false;
                            }
                        }

                        if (date.StartDate.Date == date.EndDate.Date && date.StartDate.Date == currentTask.EndDate.GetValueOrDefault().Date)
                        {
                            if (totalHourTask < 8)
                            {
                                double totalHour = (currentTask.EndDate.GetValueOrDefault() - currentTask.StartDate.GetValueOrDefault()).TotalHours;

                                totalHourInDay = totalHourInDay + totalHour;

                                if (totalHourInDay > 8)
                                {
                                    return false;
                                }

                                if (totalHourInDay <= 8)
                                {
                                    double totalHourTaskDay = totalHourInDay;
                                    totalHourTaskDay += totalHourTask;
                                    if (totalHourTaskDay > 8)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }

                    if (i > 0)
                    {
                        var previousTask = tasks[i - 1];

                        if (previousTask.EndDate.GetValueOrDefault().Date < date.StartDate.Date)
                        {
                            if (previousTask.EndDate.GetValueOrDefault().AddHours(2) > date.StartDate)
                            {
                                return false;
                            }
                        }

                        if (previousTask.EndDate.GetValueOrDefault().Date == date.StartDate.Date)
                        {
                            if (previousTask.EndDate.GetValueOrDefault().Hour <= date.StartDate.Hour)
                            {
                                if (previousTask.EndDate.GetValueOrDefault().AddHours(2) > date.StartDate)
                                {
                                    return false;
                                }
                            }
                        }
                    }


                    if (i < tasks.Count - 1)
                    {
                        var nextTask = tasks[i + 1];

                        if (nextTask.StartDate.GetValueOrDefault().Date > date.StartDate.Date)
                        {
                            if (date.EndDate.AddHours(2) > nextTask.StartDate.GetValueOrDefault())
                            {
                                return false; // Task sau chưa chuẩn bị đủ 2 giờ
                            }
                        }

                        if (nextTask.StartDate.GetValueOrDefault().Date == date.StartDate.Date)
                        {
                            if (date.EndDate.Hour < nextTask.StartDate.GetValueOrDefault().Hour)
                            {
                                if (date.EndDate.AddHours(2) > nextTask.StartDate.GetValueOrDefault())
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;

        }

        public async Task<Task> GetTaskById(string id, string accountId)
        {
            return await _dbContext.Tasks.Include(t => t.Account).FirstOrDefaultAsync(t => t.TaskId.Equals(id) && t.Account.AccountId.Equals(accountId));
        }

        public async Task<bool> UpdateTask(Task task)
        {
            _dbContext.Update(task);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Task> GetTaskByTaskId(string id)
        {
            return await _dbContext.Tasks.Include(t => t.Account).Include(t => t.ContractCharacter).Include(t => t.EventCharacter).FirstOrDefaultAsync(t => t.TaskId.Equals(id));
        }

        public async Task<List<Task>> GetTasksByAccountId(string accountId)
        {
            return await _dbContext.Tasks.Where(t => t.AccountId.Equals(accountId)).Include(t => t.ContractCharacter).Include(t => t.EventCharacter).OrderBy(t => t.StartDate).ToListAsync();
        }

        public async Task<List<Task>> GetTaskByContractCharacterId(string contractCharacterId)
        {
            return await _dbContext.Tasks.Where(c => c.ContractCharacterId.Equals(contractCharacterId)).ToListAsync();
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
