using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Services
{
    public interface IAccountService
    {
        Task<List<AccountCategoryResponse>> GetListAccountToContactByContractId(string contractId);
        Task<List<AccountCharacteRespones>> CheckForCharactersWithDuplicateCosplayers(string accountId, List<string> chacracters);
        Task<List<AccountResponse>> GetAccountsForTask(string taskId, string accountId);
        Task<bool> ChangeAccountForTask(string taskId, string accountId);
    }
    public class AccountService : IAccountService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IContractRespository contractRespository;
        private readonly ICharacterRepository characterRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public AccountService(ITaskRepository taskRepository, IAccountRepository accountRepository, IMapper mapper, ICharacterRepository characterRepository, IContractRespository contractRepository, ICategoryRepository categoryRepository)
        {
            this.taskRepository = taskRepository;
            this.accountRepository = accountRepository;
            this.mapper = mapper;
            this.characterRepository = characterRepository;
            this.contractRespository = contractRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<AccountResponse>> GetAccountsForTask(string taskId, string accountId)
        {
            try
            {
                List<AccountResponse> accountResponses = new List<AccountResponse> ();
                Task taskCurrent = await taskRepository.GetTask(taskId);
                if (taskCurrent == null)
                {
                    throw new Exception("Task does not exist");
                }

                Account checkAccount = await accountRepository.GetAccountByAccountId(accountId);
                if (checkAccount == null)
                {
                    throw new Exception("Account does not exist");
                }

                Character character = await characterRepository.GetCharacterByCharacterName(taskCurrent.TaskName);

                List<Account> accounts = await accountRepository.GetAccountByCategoryId(character.CategoryId, checkAccount.AccountId);

                foreach(var account in accounts)
                {
                    List<Task> tasks = await taskRepository.GetTaskByAccountId(account.AccountId);
                    if(!tasks.Any())
                    {
                         accountResponses.Add(mapper.Map<AccountResponse>(account));    
                    }
                    if (tasks.Any())
                    {
                        for (int i = 0; i < tasks.Count - 1; i++)
                        {
                            Task task = tasks[i];
                            Task taskNext = tasks[i + 1];

                            if (taskNext == null)
                            {
                                break;
                            }

                            if (task.StartDate.HasValue && task.EndDate.HasValue && taskNext.StartDate.HasValue && taskNext.EndDate.HasValue)
                            {
                                if (task.EndDate.Value.Date < taskCurrent.StartDate && taskCurrent.EndDate < taskNext.StartDate.Value.Date)
                                {
                                    accountResponses.Add(mapper.Map<AccountResponse>(account));
                                    break;
                                }
                            }
                        }
                    }
                }
                return accountResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountCharacteRespones>> CheckForCharactersWithDuplicateCosplayers(string accountId, List<string> characters)
        {
            List<AccountCharacteRespones> accountCharacteRespones = new List<AccountCharacteRespones>();
            Account account = await accountRepository.GetAccountIncludeAccountCategory(accountId);

            if (account == null)
            {
                return new List<AccountCharacteRespones>();
            }

            foreach (var character in characters)
            {
                Character checkCharacter = await characterRepository.GetCharacter(character);
                if (checkCharacter == null)
                {
                    return new List<AccountCharacteRespones>();
                }
                if (checkCharacter == null) continue;

                var accountCategoryResponse = new AccountCharacteRespones
                {
                    CharacterId = checkCharacter.CharacterId,
                    Duplicate = !account.AccountCategories.Any(ac => ac.CategoryId.Equals(checkCharacter.CategoryId))
                };
                accountCharacteRespones.Add(accountCategoryResponse);
            }
  
            return accountCharacteRespones;
        }

        public async Task<List<AccountCategoryResponse>> GetListAccountToContactByContractId(string contractId)
        {
            CCSS_Repository.Entities.Contract contract = await contractRespository.GetContractById(contractId);

            List<Account> accounts = new List<Account>();
            List<AccountResponse> accountResponses = new List<AccountResponse>();
            List<AccountCategoryResponse> accountCategoryResponses = new List<AccountCategoryResponse>();
            
            List<Task> tasks = new List<Task>();
            if (contract == null)
            {
                return new List<AccountCategoryResponse>();
            }
            if (contract.ContractCharacters != null)
            {
                foreach (var contractCharacter in (List<ContractCharacter>)contract.ContractCharacters)
                {
                    Character character = await characterRepository.GetCharacter(contractCharacter.CharacterId);
                    if(character != null)
                    {
                        accounts = await accountRepository.GetAccountByCategoryId(character.CategoryId, null);
                        if (accounts == null)
                        {
                            return new List<AccountCategoryResponse>();
                        }
                        foreach (var account in accounts)
                        {
                            tasks = await taskRepository.GetTaskByAccountId(account.AccountId);
                            if (!tasks.Any())
                            {
                                accountResponses.Add(mapper.Map<AccountResponse>(account));
                            }
                            if (tasks.Any())
                            {
                                for (int i = 0; i < tasks.Count - 1; i++)
                                {
                                    Task task = tasks[i];
                                    Task taskNext = tasks[i + 1];
                                    if (taskNext == null)
                                    {
                                        break;
                                    }
                                    if (task.StartDate.HasValue && task.EndDate.HasValue && taskNext.StartDate.HasValue && taskNext.EndDate.HasValue)
                                    {
                                        if (task.EndDate.Value.Date < contract.StartDate.Date && contract.EndDate.Date < taskNext.StartDate.Value.Date)
                                        {
                                            accountResponses.Add(mapper.Map<AccountResponse>(account));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        AccountCategoryResponse accountCategoryResponse = new AccountCategoryResponse()
                        {
                            CategoryId = character.CategoryId,
                            CategoryName = character.Category.CategoryName,
                            Description = character.Category.Description,
                            CharacterId = character.CharacterId,
                            Character = character.CharacterName,
                            AccountResponses = accountResponses
                        };
                        accountCategoryResponses.Add(accountCategoryResponse);
                        accountResponses = new List<AccountResponse>();
                    }
                }
            }
            return accountCategoryResponses;
        }

        public async Task<bool> ChangeAccountForTask(string taskId, string accountId)
        {
            try
            {
                Account account = await accountRepository.GetAccountByAccountId(accountId);
                Task task = await taskRepository.GetTask(taskId);

                if (task == null || account == null)
                {
                    throw new Exception("Task or account does not exist");
                }

                task.AccountId = account.AccountId;

                bool result = await taskRepository.UpdateTask(task);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
