using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model;
using CCSS_Service.Model.Responses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        Task<AccountLoginResponse> Login(string email, string password);
        Task<string> CodeValidation(string email, string code);
    }
    public class AccountService : IAccountService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IContractRespository contractRespository;
        private readonly ICharacterRepository characterRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository; 
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;

        public AccountService(ITaskRepository taskRepository, IAccountRepository accountRepository, IMapper mapper, ICharacterRepository characterRepository, IContractRespository contractRepository, ICategoryRepository categoryRepository, IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository)
        {
            this.taskRepository = taskRepository;
            this.accountRepository = accountRepository;
            this.mapper = mapper;
            this.characterRepository = characterRepository;
            this.contractRespository = contractRepository;
            this.categoryRepository = categoryRepository;
            _configuration = configuration;
            this.refreshTokenRepository = refreshTokenRepository;
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

        public async Task<AccountLoginResponse> Login(string email, string password)
        {
            try
            {
                var account = await accountRepository.GetAccountByEmailAndPassword(email, PasswordHash.ConvertToEncrypt(password));
                if (account == null)
                {
                    throw new Exception("Email or password wrong");
                }
                else
                {
                    if ((bool)!account.IsActive)
                    {
                        throw new Exception("Account has not been activated");
                    }
                    else
                    {
                        var jti = Guid.NewGuid().ToString();
                        var jwtHandler = new JwtSecurityTokenHandler();
                        var issuer = _configuration["AppSettings:Issuer"];
                        var audience = _configuration["AppSettings:Audience"];

                        var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:SecretKey"]);
                        var tokenDes = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new[]
                            {
                        new Claim("Id", account.AccountId),
                        new Claim("Email", account.Email),
                        new Claim(ClaimTypes.Role, account.Role.RoleName.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, jti)
                    }),
                            Expires = DateTime.UtcNow.AddHours(1),
                            Issuer = issuer,
                            Audience = audience, // Đảm bảo rằng giá trị này được lấy từ cấu hình
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                        };
                        var jwtToken = jwtHandler.CreateToken(tokenDes);
                        string refreshTokenValue = GenerateRefreshToken();
                        RefreshToken refreshToken = new RefreshToken
                        {
                            RefreshTokenId = Guid.NewGuid().ToString(),
                            AccountId = account.AccountId,
                            CreateAt = DateTime.UtcNow,
                            ExpiresAt = DateTime.UtcNow.AddHours(1),
                            IsUsed = false,
                            RefreshTokenValue = refreshTokenValue,
                            JwtId = jti,
                            IsRevoked = false,
                        };
                        bool result = await refreshTokenRepository.AddRefreshToken(refreshToken);
                        if (!result)
                        {
                            throw new Exception("Cannot save refresh token !!!");
                        }
                        string accessToken = jwtHandler.WriteToken(jwtToken);
                        return new AccountLoginResponse
                        {
                            AccessToken = accessToken,
                            RefreshToken = refreshTokenValue,
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public Task<string> CodeValidation(string email, string code)
        {
            throw new NotImplementedException();
        }
    }
}
