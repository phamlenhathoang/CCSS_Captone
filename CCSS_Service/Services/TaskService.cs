using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Hubs;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using iText.Layout.Element;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static iText.Svg.SvgConstants;
using Contract = CCSS_Repository.Entities.Contract;
using Request = CCSS_Repository.Entities.Request;
using Task = CCSS_Repository.Entities.Task;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Service.Services
{
    public interface ITaskService
    {
        //Task<string> UpdateStatusTask(string taskId, int taskStatus, string accountId);
        //Task<string> DeleteTask(string taskId);
        //Task<TaskResponse> GetTask(string taskId);
        ////Task<string> AddTask(List<TaskRequest> taskRequests, int quantityAccount, string contractId);
        //Task<List<TaskResponse>> GetTaskListsByAccountId(string accountId, string? taskId);
        //Task<string> AddTaskForListAccount(List<AddTaskRequest> addTaskRequests);
        //Task<List<TaskResponse>> ViewAllTaskByAccountId(string accountId, string? taskId);
        //Task<List<TaskResponse>> ViewAllTaskByContractId(string contractId);

        Task<List<TaskResponse>> GetAllTasks();
        Task<string> AddTask(List<AddTaskEventRequest>? taskEventRequests, List<ContractCharacter>? contractCharacters);
        Task<bool> UpdateStatusTask(string taskId, string status, string accountId);
        Task<List<TaskResponse>> GetTaskByAccountId(string accountId);
        Task<TaskResponse> GetTaskByTaskId(string taskId);
        Task<bool> AddTaskContractByManager(List<AddTaskContractRequest> contractCharacters, string requestId);
        Task<bool> UpdateStatusTaskByContractId(string contractId);
        Task<bool> UpdateStatusTaskByTaskId(string taskId, string status);
        Task<bool> DeleteAllTaskByEventId(string eventId);
        Task<List<TaskResponse>> GetAllTaskByRequestId(string requestId);
        Task<List<TaskResponse>> GetAllTaskByContractId(string contractId);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository accountRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IEventChacracterRepository eventChacracterRepository;
        private readonly IContractCharacterRepository contractCharacterRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IEventRepository eventRepository;
        private readonly IBeginTransactionRepository _beginTransactionRepository;
        private readonly IRequestCharacterRepository requestCharacterRepository;
        private readonly IEventCharacterRepository eventCharacterRepository;
        private readonly IRequestDatesRepository requestDatesRepository;
        private readonly INotificationService _notificationService;

        public TaskService(IRequestRepository requestRepository, IContractCharacterRepository contractCharacterRepository, IEventChacracterRepository eventChacracterRepository, ITaskRepository taskRepository, IContractRespository contractRespository, IMapper mapper, IAccountRepository accountRepository, ICharacterRepository characterRepository, IHubContext<NotificationHub> hubContext, INotificationRepository notificationRepository, IEventRepository eventRepository, IBeginTransactionRepository _beginTransactionRepository, IRequestCharacterRepository requestCharacterRepository, IEventCharacterRepository eventCharacterRepository, IRequestDatesRepository requestDatesRepository, INotificationService notificationService)
        {
            this.taskRepository = taskRepository;
            this.contractRespository = contractRespository;
            this.accountRepository = accountRepository;
            this.characterRepository = characterRepository;
            this.mapper = mapper;
            this.hubContext = hubContext;
            this.notificationRepository = notificationRepository;
            this.eventChacracterRepository = eventChacracterRepository;
            this.contractCharacterRepository = contractCharacterRepository;
            this.requestRepository = requestRepository;
            this.eventRepository = eventRepository;
            this._beginTransactionRepository = _beginTransactionRepository;
            this.requestCharacterRepository = requestCharacterRepository;
            this.eventCharacterRepository = eventCharacterRepository;
            this.requestDatesRepository = requestDatesRepository;
            _notificationService = notificationService;
        }

        private async Task<bool> AddTaskEvent(List<AddTaskEventRequest> taskEventRequests)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                try
                {
                    List<Task> tasks = new List<Task>();

                    var uniqueElements = new HashSet<string>();

                    foreach (var taskEventRequest in taskEventRequests)
                    {
                        bool checkAccount = uniqueElements.Add(taskEventRequest.AccountId);

                        if (!checkAccount)
                        {
                            throw new Exception("Account is duplicate");
                        }
                    }

                    foreach (var taskRequest in taskEventRequests)
                    {
                        Account account = await accountRepository.GetAccount(taskRequest.AccountId);
                        if (account == null)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("Account does not exist");
                        }
                        if (account.Role.RoleName != RoleName.Cosplayer)
                        {
                            throw new Exception("Account must be cosplayer");
                        }
                        EventCharacter eventCharacter = await eventChacracterRepository.GetEventCharacterById(taskRequest.EventCharacterId);
                        if (eventCharacter == null)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("EventCharacter does not exist");
                        }
                        if (eventCharacter.IsAssign == true)
                        {
                            throw new Exception("EventCharacter assigned");
                        }

                        //if (!CheckCharacterForAccount(account, eventCharacter.Character))
                        //{
                        //    throw new Exception("Cosplayer does not suitable character");
                        //}

                        Task task = new Task()
                        {
                            EventCharacterId = taskRequest.EventCharacterId,
                            AccountId = taskRequest.AccountId,
                            CreateDate = DateTime.Now,
                            Description = eventCharacter.Description,
                            EndDate = eventCharacter.Event.EndDate,
                            StartDate = eventCharacter.Event.StartDate,
                            TaskName = eventCharacter.Character.CharacterName,
                            Location = eventCharacter.Event.Location,
                            IsActive = true,
                            Status = TaskStatus.Assignment,
                            Type = "Event",
                            TaskId = Guid.NewGuid().ToString(),
                            UpdateDate = null,
                        };

                        //bool checkTask = await taskRepository.CheckTaskIsValid(account, task.StartDate.Value, task.EndDate.Value);
                        //if (!checkTask)
                        //{
                        //    throw new Exception("Task is invalid");
                        //}

                        bool check = await taskRepository.AddTask(task);

                        if (!check)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception($"Task {task.TaskId} đã xảy ra lỗi vào lúc {DateTime.Now}");
                        }
                        tasks.Add(task);
                    }

                    bool result = await NortificationUser(tasks) ? true : false;

                    await transaction.CommitAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        private bool CheckCharacterForAccount(Account account, Character character)
        {
            if (character.MinHeight <= account.Height && account.Height <= character.MaxHeight && character.MinWeight <= account.Weight && account.Weight <= character.MaxHeight)
            {
                return true;
            }
            return false;
        }



        private async Task<bool> AddTaskContract(List<ContractCharacter> contractCharacters)
        {
            try
            {
                List<Task> tasks = new List<Task>();

                var uniqueElements = new HashSet<string>();

                foreach (var taskEventRequest in contractCharacters)
                {
                    if (taskEventRequest.CosplayerId != null)
                    {
                        bool checkAccount = uniqueElements.Add(taskEventRequest.CosplayerId);

                        if (!checkAccount)
                        {
                            throw new Exception("Account is duplicate");
                        }
                    }
                }

                foreach (var taskRequest in contractCharacters)
                {
                    if (taskRequest.CosplayerId != null)
                    {
                        Account account = await accountRepository.GetAccount(taskRequest.CosplayerId);
                        if (account == null)
                        {
                            throw new Exception("Account does not exist");
                        }
                        if (account.Role.RoleName != RoleName.Cosplayer)
                        {
                            throw new Exception("Account must be cosplayer");
                        }
                        ContractCharacter contractCharacter = await contractCharacterRepository.GetContractCharacterById(taskRequest.ContractCharacterId);
                        if (contractCharacter == null)
                        {
                            //await transaction.RollbackAsync();
                            throw new Exception("ContractCharacter does not exist");
                        }

                        foreach(var item in contractCharacter.RequestDates)
                        {
                            Task task = new Task();

                            task.ContractCharacterId = taskRequest.ContractCharacterId;
                            task.AccountId = taskRequest.CosplayerId;
                            task.CreateDate = DateTime.Now;
                            task.Description = contractCharacter.Description;
                            task.EndDate = item.EndDate;
                            task.StartDate = item.StartDate;
                            task.TaskName = contractCharacter.CharacterId;
                            task.Location = contractCharacter.Contract.Request.Location;
                            task.IsActive = true;
                            task.Status = TaskStatus.Assignment;
                            task.Type = "Contract";
                            task.TaskId = Guid.NewGuid().ToString();
                            task.UpdateDate = null;

                            bool check = await taskRepository.AddTask(task);
                            if (!check)
                            {
                                //await transaction.RollbackAsync();
                                throw new Exception($"Task {task.TaskId} đã xảy ra lỗi vào lúc {DateTime.Now}");
                            }

                            //tasks.Add(task);
                        }
                    }
                }

                //bool result = await NortificationUser(tasks) ? true : false;

                //await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                //await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddTaskContractByManager(List<AddTaskContractRequest> contractCharacters, string requestId)
        {
            try
            {
                List<Task> tasks = new List<Task>();

                var uniqueElements = new HashSet<string>();

                foreach (var contractCharacter in contractCharacters)
                {
                    if (contractCharacter.CosplayerId != null)
                    {
                        bool checkAccount = uniqueElements.Add(contractCharacter.CosplayerId);

                        if (!checkAccount)
                        {
                            throw new Exception("Account is duplicate");
                        }
                    }
                }

                int count = 0;
                List<RequestDate> dates = new List<RequestDate>();

                Request request = await requestRepository.GetRequestById(requestId);
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }

                if(request.ServiceId != "S003")
                {
                    throw new Exception($"Service in this request {request.RequestId} must be S003");
                }

                foreach (var taskRequest in contractCharacters)
                {
                    if (taskRequest.CosplayerId != null)
                    {
                        Account account = await accountRepository.GetAccount(taskRequest.CosplayerId);
                        if (account == null)
                        {
                            throw new Exception("Account does not exist");
                        }
                        if (account.Role.RoleName != RoleName.Cosplayer)
                        {
                            throw new Exception("Account must be cosplayer");
                        }

                        RequestCharacter requestCharacter = await requestCharacterRepository.GetRequestCharacterById(taskRequest.RequestCharacterId);

                        if (requestCharacter == null)
                        {
                            throw new Exception("Character does not exist");
                        }

                        Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);
                        double totalDay = (request.EndDate - request.StartDate).TotalDays + 1;
                        double totalHour = 0;

                        if (count == 0)
                        {
                            foreach (RequestDate requestDate in requestCharacter.RequestDates)
                            {
                                dates.Add(requestDate);
                            }

                            count++;
                        }

                        foreach (RequestDate requestDate in dates)
                        {
                            double hour = (requestDate.EndDate - requestDate.StartDate).TotalHours;
                            totalHour += hour;
                        }

                        if (requestCharacter.Quantity == 1)
                        {
                            requestCharacter.CosplayerId = taskRequest.CosplayerId;
                            requestCharacter.TotalPrice = (character.Price * totalDay) + (account.SalaryIndex * totalHour);

                            bool checkUpdate = await requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
                            if (!checkUpdate)
                            {
                                throw new Exception("Can not update RequestCharacter");
                            }
                        }

                        if (requestCharacter.Quantity > 1)
                        {
                            RequestCharacter newRequestCharacter = new RequestCharacter()
                            {
                                CosplayerId = taskRequest.CosplayerId,
                                CharacterId = requestCharacter.CharacterId,
                                Description = null,
                                CreateDate = DateTime.Now,
                                Quantity = 1,
                                RequestId = requestId,
                                UpdateDate = null,
                                TotalPrice = (character.Price * totalDay) + (account.SalaryIndex * totalHour),
                            };

                            bool result = await requestCharacterRepository.AddRequestCharacter(newRequestCharacter);

                            if (!result)
                            {
                                throw new Exception("Can not add RequestCharacter");
                            }

                            foreach (RequestDate requestDate in dates)
                            {
                                RequestDate newRequestDate = new RequestDate()
                                {
                                    RequestCharacterId = newRequestCharacter.RequestCharacterId,
                                    StartDate = requestDate.StartDate,
                                    EndDate = requestDate.EndDate,
                                    Status = RequestDateStatus.Accept,
                                };

                                bool checkAdd = await requestDatesRepository.AddRequestDate(newRequestDate);
                                if (!checkAdd)
                                {
                                    throw new Exception("Can not add RequestDate");
                                }
                            }

                            // tuananh create send notification
                            SendMail sendMail = new SendMail();
                            var accountCosplayer = await accountRepository.GetAccount(taskRequest.CosplayerId);
                            var resultSendMail = await sendMail.SendEmailRequestForCosplayer(accountCosplayer.Email);
                            if (!resultSendMail)
                            {
                               return false;
                            }
                            else
                            {
                                string message = "There are some request you need to review.";
                                await _notificationService.SendNotification(accountCosplayer.AccountId, message);

                                string messageForCustomer = "Manager have assign task for cosplayer already. Please check request";
                                await _notificationService.SendNotification(request.AccountId, messageForCustomer);
                            }
                            //

                            requestCharacter.Quantity -= 1;

                            bool checkUpdate = await requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
                            if (!checkUpdate)
                            {
                                throw new Exception("Can not update RequestCharacter");
                            }

                        }
                    }
                }

                double price = 0;

                foreach(RequestCharacter requestCharacter1 in request.RequestCharacters)
                {
                    price += (double) requestCharacter1.TotalPrice;
                }

                request.Price = price + request.Package.Price;

                await requestRepository.UpdateRequest(request);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> NortificationUser(List<Task> tasks)
        {
            List<Notification> notificationList = new List<Notification>();

            foreach (var task in tasks)
            {
                string connectionId = NotificationHub.GetConnectionId(task.AccountId);
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
            bool result = await notificationRepository.AddRangeNotification(notificationList) ? true : false;

            return result;
        }

        public async Task<string> AddTask(List<AddTaskEventRequest>? taskEventRequests, List<ContractCharacter>? contractCharacters)
        {
            try
            {
                if (taskEventRequests != null)
                {
                    bool result = await AddTaskEvent(taskEventRequests) ? true : false;
                    if (result)
                    {
                        //await transaction.CommitAsync();
                        return "Successfully";
                    }
                }

                if (contractCharacters != null)
                {
                    bool result = await AddTaskContract(contractCharacters) ? true : false;
                    if (result)
                    {
                        //await transaction.CommitAsync();
                        return "Successfully";
                    }
                }
                //await transaction.RollbackAsync();
                return "Failed";
            }
            catch (Exception ex)
            {
                //await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskResponse>> GetAllTasks()
        {
            try
            {
                List<TaskResponse> taskResponses = new List<TaskResponse>();
                List<Task> tasks = await taskRepository.GetAllTask();
                foreach (Task task in tasks)
                {
                    Character character = await characterRepository.GetCharacter(task.TaskName);
                    if (character == null)
                    {
                        throw new Exception("Character does not exist");
                    }
                    var taskResponse = new TaskResponse()
                    {
                        TaskName = character.CharacterName,
                        AccountId = task.AccountId,
                        CreateDate = task.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        Description = task.Description,
                        EndDate = task.EndDate?.ToString("HH:mm dd/MM/yyyy"),
                        IsActive = task.IsActive,
                        Location = task.Location,
                        StartDate = task.StartDate?.ToString("HH:mm dd/MM/yyyy"),
                        Status = task.Status.ToString(),
                        TaskId = task.TaskId,
                        UpdateDate = task.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                    };
                     
                    if(task.ContractCharacterId != null)
                    {
                        ContractCharacter contractCharacter = await contractCharacterRepository.GetContractCharacterById(task.ContractCharacterId);
                        taskResponse.ContractId = contractCharacter.ContractId;
                    }

                    if (task.EventCharacterId != null)
                    {
                        EventCharacter eventCharacter = await eventChacracterRepository.GetEventCharacterById(task.EventCharacterId);
                        taskResponse.EventId = eventCharacter.EventId;
                    }

                    taskResponses.Add(taskResponse);    
                }
               
                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateStatusTask(string taskId, string status, string accountId)
        {
            try
            {
                Account account = await accountRepository.GetAccount(accountId);
                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }
                if(account.Role.RoleName != RoleName.Cosplayer)
                {
                    throw new Exception("Account must be cosplayer");
                }
                Task task = await taskRepository.GetTaskById(taskId, accountId);
                if (task == null)
                {
                    throw new Exception($"{taskId} was not found");
                }

                if(task.Account == null)
                {
                    throw new Exception("Cosplayer does not exist");
                }

                if (status.ToLower().Equals(TaskStatus.Progressing.ToString().ToLower()))
                {
                    if (task.Status.ToString().ToLower().Equals(TaskStatus.Assignment.ToString().ToLower()))
                    {
                        task.Status = TaskStatus.Progressing;
                        task.UpdateDate = DateTime.Now; 
                    }
                    else
                    {
                        throw new Exception("Can not update status");
                    }
                }
                if (status.ToLower().Equals(TaskStatus.Completed.ToString().ToLower()))
                {
                    if (task.Status.ToString().ToLower().Equals(TaskStatus.Progressing.ToString().ToLower()))
                    {
                        task.Status = TaskStatus.Completed;
                        task.UpdateDate = DateTime.Now;
                    }
                    else
                    {
                        throw new Exception("Can not update status");
                    }
                }

                bool result = await taskRepository.UpdateTask(task);
                if (!result)
                {
                    throw new Exception("Can not update status task");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskResponse>> GetTaskByAccountId(string accountId)
        {
            try
            {
                Account account = await accountRepository.GetAccount(accountId);
                if(account == null)
                {
                    throw new Exception("Account does not exist");
                }

                if (account.Role.RoleName != RoleName.Cosplayer)
                {
                    throw new Exception("Account must be cosplayer");
                }

                List<TaskResponse> taskResponses = new List<TaskResponse>();
                var tasks = await taskRepository.GetTasksByAccountId(accountId);
                if (tasks == null)
                {
                    throw new Exception("Task does not exist");
                }

                foreach (var task in tasks)
                {
                    
                    Character character = await characterRepository.GetCharacter(task.TaskName);
                    if (character == null)
                    {
                        throw new Exception("Character does not exist");
                    }

                    var tasResponse = new TaskResponse()
                    {
                        AccountId = task.AccountId,
                        CreateDate = task.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        Description = task.Description,
                        EndDate = task.EndDate?.ToString("HH:mm dd/MM/yyyy"),
                        IsActive = task.IsActive,
                        Location = task.Location,
                        StartDate = task.StartDate?.ToString("HH:mm dd/MM/yyyy"),
                        Status = task.Status.ToString(),
                        TaskId = task.TaskId,
                        TaskName = character.CharacterName,
                        UpdateDate = task.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                    };

                    if (task.ContractCharacterId != null)
                    {
                        ContractCharacter contractCharacter = await contractCharacterRepository.GetContractCharacterById(task.ContractCharacterId);

                        if (contractCharacter == null)
                        {
                            throw new Exception("ContractCharacter does not exist");
                        }

                        tasResponse.ContractId = contractCharacter.ContractId;
                    }

                    if (task.EventCharacterId != null)
                    {
                        EventCharacter eventCharacter = await eventChacracterRepository.GetEventCharacterById(task.EventCharacterId);

                        if (eventCharacter == null)
                        {
                            throw new Exception("EventCharacter does not exist");
                        }

                        tasResponse.EventId = eventCharacter.EventId;
                    }

                    taskResponses.Add(tasResponse);
                }

                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskResponse> GetTaskByTaskId(string taskId)
        {
            try
            {
                var task = await taskRepository.GetTaskByTaskId(taskId);
                if (task == null)
                {
                    throw new Exception("Task does not exist");
                }

                Contract contract = new Contract();

                if(task.ContractCharacter != null)
                {
                    contract = await contractRespository.GetContractById(task.ContractCharacter.ContractId);
                    if(contract == null)
                    {
                        throw new Exception("Contract does not exist");
                    }
                }

                Character character = await characterRepository.GetCharacter(task.TaskName);
                if (character == null)
                {
                    throw new Exception("Character does not exist");
                }

                Event e = new Event();
                if (task.EventCharacter != null)
                {
                    e = await eventRepository.GetEventByEventId(task.EventCharacter.EventId);   
                    if(e == null)
                    {
                        throw new Exception("Event does not exist");
                    }
                }

                var taskResponse = new TaskResponse()
                {
                    AccountId = task.AccountId,
                    ContractId = contract.ContractId,
                    CreateDate = task.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                    Description = task.Description,
                    EndDate = task.EndDate?.ToString("HH:mm dd/MM/yyyy"),
                    EventId = e.EventId,
                    IsActive = task.IsActive,
                    Location = task.Location,
                    StartDate = task.StartDate?.ToString("HH:mm dd/MM/yyyy"),
                    Status = task.Status.ToString(),
                    TaskId = task.TaskId,
                    TaskName = character.CharacterName,
                    UpdateDate = task.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                };

                return taskResponse;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateStatusTaskByContractId(string contractId)
        {
            try
            {
                Contract contract = await contractRespository.GetContractById(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if (contract.ContractCharacters.Any())
                {
                    foreach (var contractCharacter in contract.ContractCharacters)
                    {
                        var tasks = await taskRepository.GetTaskByContractCharacterId(contractCharacter.ContractCharacterId);
                        if (tasks != null)
                        {
                            foreach (var task in tasks)
                            {
                                task.Status = TaskStatus.Completed;
                                task.UpdateDate = DateTime.Now;
                                bool result = await taskRepository.UpdateTask(task);
                                if (!result)
                                {
                                    throw new Exception("Can not update status task");
                                }
                            }
                        }
                    }
                }

                return true;    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateStatusTaskByTaskId(string taskId, string status)
        {
            try
            {
                Task task = await taskRepository.GetTaskByTaskId(taskId);
                if (task == null)
                {
                    throw new Exception("Task does not exist");
                }

                if (status.ToLower().Equals(TaskStatus.Progressing.ToString().ToLower()))
                {
                    if (task.Status.ToString().ToLower().Equals(TaskStatus.Assignment.ToString().ToLower()))
                    {
                        task.Status = TaskStatus.Progressing;
                        task.UpdateDate = DateTime.Now;
                    }
                    else
                    {
                        throw new Exception("Can not update status");
                    }
                }
                if (status.ToLower().Equals(TaskStatus.Completed.ToString().ToLower()))
                {
                    if (task.Status.ToString().ToLower().Equals(TaskStatus.Progressing.ToString().ToLower()))
                    {
                        task.Status = TaskStatus.Completed;
                        task.UpdateDate = DateTime.Now;
                    }
                    else
                    {
                        throw new Exception("Can not update status");
                    }
                }

                bool result = await taskRepository.UpdateTask(task);

                if (!result)
                {
                    throw new Exception("Can not update status");
                }

                return result;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAllTaskByEventId(string eventId)
        {
            try
            {
                Event e = await eventRepository.GetEventByEventId(eventId);

                if (e == null)
                {
                    throw new Exception("Event does not exist");
                }

                if(e.EventCharacters == null)
                {
                    throw new Exception("EventCharacters does not exist");
                }

                foreach (EventCharacter item in e.EventCharacters)
                {
                    EventCharacter eventCharacter = await eventChacracterRepository.GetEventCharacterById(item.EventCharacterId);

                    if (eventCharacter == null)
                    {
                        throw new Exception("EventCharacter does not exist");
                    }

                    if(eventCharacter.Task.Status != TaskStatus.Assignment)
                    {
                        throw new Exception("Can not update task becaue this task inprogressing");
                    }

                    eventCharacter.Task.IsActive = false;

                    bool result = await taskRepository.UpdateTask(eventCharacter.Task);

                    if (!result)
                    {
                        throw new Exception("Can not update task");
                    }

                    SendMail sendMail = new SendMail();

                    await sendMail.SendCosplayerUpdateTask(eventCharacter.Task.Account.Email);
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskResponse>> GetAllTaskByRequestId(string requestId)
        {
            try
            {
                List<TaskResponse> taskResponses = new List<TaskResponse>();

                Request request = await requestRepository.GetRequestById(requestId);
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }

                if(request.ServiceId != "S003")
                {
                    throw new Exception("ServiceId of request must be S003");
                }

                if(request.Contract == null)
                {
                    throw new Exception("Request has not created contract yet");
                }

                if(request.Contract.ContractCharacters == null)
                {
                    throw new Exception("Request has created contract but no deposit yet");
                }

                foreach (ContractCharacter contractCharacter in request.Contract.ContractCharacters)
                {
                    var tasks = await taskRepository.GetTaskByContractCharacterId(contractCharacter.ContractCharacterId);

                    foreach (var task in tasks)
                    {
                        Character character = await characterRepository.GetCharacter(task.TaskName);
                        if (character == null)
                        {
                            throw new Exception("Character does not exist");
                        }
                        var taskResponse = new TaskResponse()
                        {
                            TaskName = character.CharacterName,
                            AccountId = task.AccountId,
                            CreateDate = task.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                            Description = task.Description,
                            EndDate = task.EndDate?.ToString("HH:mm dd/MM/yyyy"),
                            IsActive = task.IsActive,
                            Location = task.Location,
                            StartDate = task.StartDate?.ToString("HH:mm dd/MM/yyyy"),
                            Status = task.Status.ToString(),
                            TaskId = task.TaskId,
                            UpdateDate = task.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                            ContractId = request.Contract.ContractId,
                        };

                        taskResponses.Add(taskResponse);
                    }
                }

                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskResponse>> GetAllTaskByContractId(string contractId)
        {
            try
            {
                List<TaskResponse> taskResponses = new List<TaskResponse>();
                Contract contract = await contractRespository.GetContractById(contractId);

                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }


                if (contract.ContractCharacters.Count > 0)
                {
                    foreach (var contractCharacter in contract.ContractCharacters)
                    {
                        List<Task> tasks = await taskRepository.GetTaskByContractCharacterId(contractCharacter.ContractCharacterId);

                        if (tasks.Count > 0)
                        {
                            foreach (var task in tasks)
                            {
                                TaskResponse taskResponse = new TaskResponse()
                                {
                                    AccountId = task.AccountId,
                                    ContractId = contractCharacter.ContractId,
                                    CreateDate = task.CreateDate?.ToString("dd/MM/yyyy"),
                                    Description = task.Description,
                                    IsActive = task.IsActive,
                                    StartDate = task.StartDate?.ToString("dd/MM/yyyy"),
                                    EndDate = task.EndDate?.ToString("dd/MM/yyyy"),
                                    Location = task.Location,
                                    Status = task.Status.ToString(),
                                    TaskId = task.TaskId,
                                    TaskName = task.TaskName,
                                    UpdateDate = task.UpdateDate?.ToString("dd/MM/yyyy")
                                };
                                
                                taskResponses.Add(taskResponse);
                            }
                        }
                        else
                        {
                            throw new Exception("ContractCharacter does not exist");
                        }
                    }
                }

                return taskResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
