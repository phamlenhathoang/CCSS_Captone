using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Hubs;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.Svg.SvgConstants;
using Contract = CCSS_Repository.Entities.Contract;
using Task = CCSS_Repository.Entities.Task;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Service.Services
{
    public interface ITaskService
    {
        Task<string> UpdateStatusTask(string taskId, int taskStatus, string accountId);
        Task<string> DeleteTask(string taskId);
        Task<TaskResponse> GetTask(string taskId);
        //Task<string> AddTask(List<TaskRequest> taskRequests, int quantityAccount, string contractId);
        Task<List<TaskResponse>> GetTaskListsByAccountId(string accountId, string? taskId);
        Task<string> AddTaskForListAccount(List<AddTaskRequest> addTaskRequests);
        Task<List<TaskResponse>> ViewAllTaskByAccountId(string accountId, string? taskId);
        Task<List<TaskResponse>> ViewAllTaskByContractId(string contractId);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository accountRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;
        private readonly IHubContext<TaskHub> hubContext;

        public TaskService(ITaskRepository taskRepository, IContractRespository contractRespository, IMapper mapper, IAccountRepository accountRepository, ICharacterRepository characterRepository, IHubContext<TaskHub> hubContext, INotificationRepository notificationRepository)
        {
            this.taskRepository = taskRepository;
            this.contractRespository = contractRespository;
            this.accountRepository = accountRepository;
            this.characterRepository = characterRepository;
            this.mapper = mapper;
            this.hubContext = hubContext;
            this.notificationRepository = notificationRepository;
        }

        //public async Task<string> AddTask(List<TaskRequest> taskRequests, int quantityAccount, string contractId)
        //{
        //    HashSet<string> accountIds = new HashSet<string>();
        //    List<Task> tasks = new List<Task>();
        //    foreach (var taskRequest in taskRequests)
        //    {
        //        if (!accountIds.Add(taskRequest.AccountId))
        //        {
        //            return "Cannot add task because you have added 1 account to multiple categories";
        //        }
        //    }

        //    if (accountIds.Count != quantityAccount)
        //    {
        //        return "Please add tasks for all employees in accordance with the contract";
        //    }

        //    Contract contract =  await contractRespository.GetContractById(contractId);

        //    if (contract == null)
        //    {
        //        return "Contract does not exist";
        //    }

        //    if(contract.Description == ContractDescription.CreateEvent)
        //    {
        //        List<Account> accounts = await accountRepository.GetAllAccountOrganizer();
        //        Account account = accounts[0];
        //        Task task = new Task()
        //        {
        //            TaskId = Guid.NewGuid().ToString(),
        //            Status = CCSS_Repository.Entities.TaskStatus.Pending,
        //            AccountId = account.AccountId,
        //            ContractId = contractId,
        //            CreateDate = DateTime.UtcNow,
        //            Description = contract.Description.ToString(),
        //            StartDate = contract.StartDate,
        //            EndDate = contract.EndDate,
        //            TaskName = contract.Description.ToString(),
        //            Location = contract.Location,
        //            IsActive = true,

        //        };

        //        tasks.Add(task);
        //    }

        //    foreach (var taskRequest in taskRequests)
        //    {
        //        Account account = await accountRepository.GetAccount(taskRequest.AccountId);

        //        if (account == null)
        //        {
        //            return "Account does not exist";
        //        }

        //        Task task = mapper.Map<Task>(taskRequest);
        //        task.TaskId = Guid.NewGuid().ToString();
        //        task.Status = CCSS_Repository.Entities.TaskStatus.Pending;

        //        if (contract == null)
        //        {
        //            return "Contract does not exist";
        //        }

        //        task.CreateDate = DateTime.Now;
        //        task.StartDate = contract.StartDate;
        //        task.EndDate = contract.EndDate;
        //        task.UpdateDate = null;
        //        task.Description = contract.Description.ToString();
        //        task.ContractId = contract.ContractId;
        //        task.TaskName = taskRequest.CharacterName;
        //        task.IsActive = true;

        //        tasks.Add(task);
        //    }

        //    bool result = await taskRepository.AddRangeTask(tasks);
        //    List<Notification> notificationList = new List<Notification>();

        //    if (result)
        //    {
        //        foreach (var task in tasks)
        //        {
        //            string connectionId = TaskHub.GetConnectionId(task.AccountId);
        //            string message = $"You have just received a new task";
        //            if (!string.IsNullOrEmpty(connectionId))
        //            {
        //                await hubContext.Clients.Client(connectionId).SendAsync("ReceiveTaskNotification", message);
        //            }
        //            else
        //            {
        //                Console.WriteLine($"User {task.AccountId} không online, không thể gửi thông báo");
        //                var notification = new Notification()
        //                {
        //                    AccountId = task.AccountId,
        //                    Message = message,
        //                    Id = Guid.NewGuid().ToString(),
        //                };
        //                notificationList.Add(notification);
        //            }
        //        }
        //    }

        //    bool resultNotification = await notificationRepository.AddRangeNotification(notificationList);

        //    return resultNotification ? "Successfully" : "Failed";
        //}

        public async Task<string> AddTaskForListAccount(List<AddTaskRequest> addTaskRequests)
        {
            List<Task> tasks = new List<Task>();
            bool checkContract = false;
            foreach (var addTaskRequest in addTaskRequests)
            {
                Character character = await characterRepository.GetCharacter(addTaskRequest.CharacterId);

                if (character == null)
                {
                    return addTaskRequest.CharacterId + " does not exist";
                }

                Contract contract = await contractRespository.GetContractById(addTaskRequest.ContractId);

                if (contract == null)
                {
                    return addTaskRequest.ContractId + " does not exist";
                }

                if (!checkContract && contract.Description == ContractDescription.CreateEvent)
                {
                    List<Account> accounts = await accountRepository.GetAllAccountLeader();
                    Account account = accounts[0];
                    Task task = new Task()
                    {
                        TaskId = Guid.NewGuid().ToString(),
                        Status = CCSS_Repository.Entities.TaskStatus.Pending,
                        AccountId = account.AccountId,
                        ContractId = contract.ContractId,
                        CreateDate = DateTime.UtcNow,
                        Description = contract.Description.ToString(),
                        StartDate = contract.StartDate,
                        EndDate = contract.EndDate,
                        TaskName = contract.Description.ToString(),
                        Location = contract.Location,
                        IsActive = true,

                    };

                    tasks.Add(task);

                    checkContract = true;
                }



                if (addTaskRequest.QuantityCharacter != addTaskRequest.AccountIds.Count())
                {
                    return addTaskRequest.CharacterId + "not enough staff";
                }

                foreach (var accountId in addTaskRequest.AccountIds)
                {
                    Account account = await accountRepository.GetAccountIncludeAccountCategory(accountId);
                    bool checkAccount = account.AccountCategories.Any(ac => ac.CategoryId.Equals(character.CategoryId));
                    if (!checkAccount)
                    {
                        return account.AccountId + " cannot cosplay " + character.CharacterId;
                    }

                    Task task = new Task()
                    {
                        AccountId = account.AccountId,
                        ContractId = contract.ContractId,
                        CreateDate = DateTime.Now,
                        Description = contract.Description.ToString(),
                        StartDate = contract.StartDate,
                        EndDate = contract.EndDate,
                        IsActive = true,
                        Status = TaskStatus.Pending,
                        Location = contract.Location,
                        TaskName = character.CharacterName,
                        TaskId = Guid.NewGuid().ToString(),
                        UpdateDate = null,
                    };
                    tasks.Add(task);
                }
            }

            bool result = await taskRepository.AddRangeTask(tasks);
            List<Notification> notificationList = new List<Notification>();

            if (result)
            {
                foreach (var task in tasks)
                {
                    string connectionId = TaskHub.GetConnectionId(task.AccountId);
                    string message = $"You have just received a new task";
                    if (!string.IsNullOrEmpty(connectionId))
                    {
                        await hubContext.Clients.Client(connectionId).SendAsync("ReceiveTaskNotification", message);
                    }
                    else
                    {
                        Console.WriteLine($"User {task.AccountId} không online, không thể gửi thông báo");
                        var notification = new Notification()
                        {
                            AccountId = task.AccountId,
                            Message = message,
                            Id = Guid.NewGuid().ToString(),
                        };
                        notificationList.Add(notification);
                    }
                }
            }

            bool resultNotification = await notificationRepository.AddRangeNotification(notificationList);

            return resultNotification ? "Successfully" : "Failed";
        }

        public async Task<string> DeleteTask(string taskId)
        {
            var checkTask = await taskRepository.GetTask(taskId);
            if (checkTask == null)
            {
                return "Task does not exist";
            }
            checkTask.IsActive = false;
            bool result = await taskRepository.UpdateTask(checkTask);
            return result ? "Delete task successfully" : "Delete task failed";
        }

        public async Task<TaskResponse> GetTask(string taskId)
        {
            var checkTask = await taskRepository.GetTask(taskId);
            if (checkTask == null)
            {
                return null;
            }
            TaskResponse task = new TaskResponse()
            {
                AccountId = checkTask.AccountId,
                ContractId = checkTask.ContractId,
                CreateDate = checkTask.CreateDate,
                Description = checkTask.Description,
                EndDate = checkTask.EndDate,
                Status = checkTask.Status.ToString(),
                EventId = checkTask.EventId,
                IsActive = checkTask.IsActive,
                Location = checkTask.Location,
                StartDate = checkTask.StartDate,
                TaskId = checkTask.TaskId,
                TaskName = checkTask.TaskName,
                UpdateDate = checkTask.UpdateDate,
            };
            return task;
        }

        public async Task<List<TaskResponse>> GetTaskListsByAccountId(string accountId, string? taskId)
        {
            Account account = await accountRepository.GetAccount(accountId);
            if (account == null)
            {
                return new List<TaskResponse>();
            }

            List<Task> tasks = await taskRepository.GetTaskByAccountId(accountId, taskId);
            return mapper.Map<List<TaskResponse>>(tasks);
        }

        public async Task<string> UpdateStatusTask(string taskId, int taskStatus, string accountId)
        {
            var checkAccount = await accountRepository.GetAccount(accountId);
            if (checkAccount == null)
            {
                return "Account does not have permisson to update";
            }
            var checkTask = await taskRepository.GetTask(taskId);
            if (checkTask == null)
            {
                return "Task does not exist";
            }
            if (checkTask.Status == CCSS_Repository.Entities.TaskStatus.Cancel)
            {
                return "A canceled task cannot be updated";
            }
            bool checkNewStatus = IsValidStatusTransition(checkTask.Status, (CCSS_Repository.Entities.TaskStatus)taskStatus);
            if (checkNewStatus)
            {
                checkTask.Status = (CCSS_Repository.Entities.TaskStatus)taskStatus;
                bool result = await taskRepository.UpdateTask(checkTask);
                return result ? "Update task successfully" : "Update task failed";
            }
            return null;
        }

        public async Task<List<TaskResponse>> ViewAllTaskByAccountId(string accountId, string? taskId)
        {
            try
            {
                List<TaskResponse> taskResponses = new List<TaskResponse>();
                Account acount = await accountRepository.GetAccountByAccountIdIncludeTask(accountId, taskId);

                if (acount == null)
                {
                    throw new Exception("Account does not exist");
                }

                foreach (Task task in acount.Tasks)
                {
                    TaskResponse taskResponse = new TaskResponse()
                    {
                        AccountId = task.AccountId,
                        ContractId = task.ContractId,
                        CreateDate = task.CreateDate,
                        Description = task.Description,
                        EndDate = task.EndDate,
                        Status = task.Status.ToString(),
                        EventId = task.EventId,
                        IsActive = task.IsActive,
                        Location = task.Location,
                        StartDate = task.StartDate,
                        TaskId = task.TaskId,
                        TaskName = task.TaskName,
                        UpdateDate = task.UpdateDate,
                    };
                    taskResponses.Add(taskResponse);
                }
                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<TaskResponse>> ViewAllTaskByContractId(string contractId)
        {
            try
            {
                List<TaskResponse> taskResponses = new List<TaskResponse>();
                Contract contract = await contractRespository.GetContractAndTasks(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }
                foreach (Task task in contract.Tasks)
                {
                    TaskResponse taskResponse = new TaskResponse()
                    {
                        AccountId = task.AccountId,
                        ContractId = task.ContractId,
                        CreateDate = task.CreateDate,
                        Description = task.Description,
                        EndDate = task.EndDate,
                        Status = task.Status.ToString(),
                        EventId = task.EventId,
                        IsActive = task.IsActive,
                        Location = task.Location,
                        StartDate = task.StartDate,
                        TaskId = task.TaskId,
                        TaskName = task.TaskName,
                        UpdateDate = task.UpdateDate,
                    };
                    taskResponses.Add(taskResponse);
                }
                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        private bool IsValidStatusTransition(CCSS_Repository.Entities.TaskStatus? currentStatus, CCSS_Repository.Entities.TaskStatus newStatus)
        {
            if (currentStatus == CCSS_Repository.Entities.TaskStatus.Pending && newStatus == CCSS_Repository.Entities.TaskStatus.Assignment)
                return true;

            if (currentStatus == CCSS_Repository.Entities.TaskStatus.Assignment && newStatus == CCSS_Repository.Entities.TaskStatus.Progressing)
                return true;

            if (currentStatus == CCSS_Repository.Entities.TaskStatus.Progressing && newStatus == CCSS_Repository.Entities.TaskStatus.Completed)
                return true;

            return false;
        }
    }
}
