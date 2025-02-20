using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ITaskService
    {
        Task<bool> AddTask(string contractId);
        Task<bool> UpdateStatusTask(string taskId, int taskStatus, string accountId);
        Task<bool> DeleteTask(string taskId);
        Task<TaskResponse> GetTask(string taskId);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository accountRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly IMapper mapper;

        public TaskService(ITaskRepository taskRepository, IContractRespository contractRespository, IMapper mapper, IAccountRepository accountRepository, ICharacterRepository characterRepository)
        {
            this.taskRepository = taskRepository;
            this.contractRespository = contractRespository; 
            this.accountRepository = accountRepository;
            this.characterRepository = characterRepository;
            this.mapper = mapper;
        }

        public async Task<bool> AddTask(string contractId)
        {
            CCSS_Repository.Entities.Contract contract = await contractRespository.GetContractById(contractId);
            if (contract == null)
            {
                return false;
            }
            if (contract.ContractCharacters != null)
            {
                foreach (var contractCharacter in (List<ContractCharacter>)contract.ContractCharacters)
                {
                    Character character = await characterRepository.GetCharacter(contractCharacter.CharacterId);
                    List<Account> accounts = await accountRepository.GetAccountByCategoryId(character.CategoryId, contractCharacter.Quantity, contract.StartDate, contract.EndDate);
                    if (accounts == null)
                    {
                        throw new Exception("Insufficient staff");
                    }
                    foreach (var account in accounts)
                    {
                        CCSS_Repository.Entities.Task task = new CCSS_Repository.Entities.Task
                        {
                            AccountId = account.AccountId,
                            ContractId = contractId,
                            CreateDate = DateTime.UtcNow,
                            Description = contract.Description,
                            Location = contract.Location,
                            EventId = null,
                            IsActive = true,
                            TaskName = character.CharacterName,
                            Status = CCSS_Repository.Entities.TaskStatus.Assignment,
                            StartDate = contract.StartDate,
                            EndDate = contract.EndDate,
                            UpdateDate = null,
                        };
                        bool result = await taskRepository.AddTask(task);
                        if (!result)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;    
        }

        public async Task<bool> DeleteTask(string taskId)
        {
            var checkTask = await taskRepository.GetTask(taskId);
            if (checkTask == null)
            {
                return false;
            }
            checkTask.IsActive = false;
            bool result = await taskRepository.UpdateTask(checkTask);
            return result;  
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

        public async Task<bool> UpdateStatusTask(string taskId, int taskStatus, string accountId)
        {
            var checkAccount = await accountRepository.GetAccount(accountId);
            if (checkAccount == null)
            {
                return false;
            }
            var checkTask = await taskRepository.GetTask(taskId);
            if(checkTask == null)
            {
                return false ;
            }
            if(checkTask.Status == CCSS_Repository.Entities.TaskStatus.Cancel)
            {
                return false;
            }
            bool checkNewStatus = IsValidStatusTransition(checkTask.Status, (CCSS_Repository.Entities.TaskStatus)taskStatus);
            if (checkNewStatus)
            {
                checkTask.Status = (CCSS_Repository.Entities.TaskStatus)taskStatus;
                bool result = await taskRepository.UpdateTask(checkTask);
                return result;
            }
            return false;   
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
