using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Google.Apis.Storage.v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
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
        //Task<List<AccountCategoryResponse>> GetListAccountToContactByContractId(string contractId);
        //Task<List<AccountCharacteRespones>> CheckForCharactersWithDuplicateCosplayers(string accountId, List<string> chacracters);
        //Task<List<AccountResponse>> GetAccountsForTask(string taskId, string accountId);
        //Task<bool> ChangeAccountForTask(string taskId, string accountId);
        Task<AccountLoginResponse> Login(string email, string password);
        Task<string> Register(AccountRequest accountRequest); 
        Task<string> CodeValidation(string email, string code);
        Task<AccountResponse> GetAccountByAccountId(string accountId);
        Task<bool> UpdateAccountByAccountId(string accountId, UpdateAccountRequest updateAccountRequest);
        Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDate(string characterId, string startDate, string endDate);
        Task<List<AccountByCharacterAndDateResponse>> ViewAllAccountByCharacterName(string characterName, string? start, string? end);
    }
    public class AccountService : IAccountService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IAccountRepository accountRepository;
        //private readonly IContractRespository contractRespository;
        private readonly ICharacterRepository characterRepository;
        //private readonly ICategoryRepository categoryRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;

        public AccountService(ITaskRepository taskRepository, IAccountRepository accountRepository, IMapper mapper, ICharacterRepository characterRepository, /*IContractRespository contractRepository, ICategoryRepository categoryRepository,*/ IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository, IEmailService emailService)
        {
            this.taskRepository = taskRepository;
            this.accountRepository = accountRepository;
            this.mapper = mapper;
            this.characterRepository = characterRepository;
            //this.contractRespository = contractRepository;
            //this.categoryRepository = categoryRepository;
            _configuration = configuration;
            this.refreshTokenRepository = refreshTokenRepository;
            _emailService = emailService;
        }

        //public async Task<List<AccountResponse>> GetAccountsForTask(string taskId, string accountId)
        //{
        //    try
        //    {
        //        List<AccountResponse> accountResponses = new List<AccountResponse>();
        //        Task taskCurrent = await taskRepository.GetTask(taskId);
        //        if (taskCurrent == null)
        //        {
        //            throw new Exception("Task does not exist");
        //        }

        //        Account checkAccount = await accountRepository.GetAccountByAccountId(accountId);
        //        if (checkAccount == null)
        //        {
        //            throw new Exception("Account does not exist");
        //        }

        //        Character character = await characterRepository.GetCharacterByCharacterName(taskCurrent.TaskName);

        //        List<Account> accounts = await accountRepository.GetAccountByCategoryId(character.CategoryId, checkAccount.AccountId);

        //        foreach (var account in accounts)
        //        {
        //            List<Task> tasks = await taskRepository.GetTaskByAccountId(account.AccountId);
        //            if (!tasks.Any())
        //            {
        //                accountResponses.Add(mapper.Map<AccountResponse>(account));
        //            }
        //            if (tasks.Any())
        //            {
        //                for (int i = 0; i < tasks.Count - 1; i++)
        //                {
        //                    Task task = tasks[i];
        //                    Task taskNext = tasks[i + 1];

        //                    if (taskNext == null)
        //                    {
        //                        break;
        //                    }

        //                    if (task.StartDate.HasValue && task.EndDate.HasValue && taskNext.StartDate.HasValue && taskNext.EndDate.HasValue)
        //                    {
        //                        if (task.EndDate.Value.Date < taskCurrent.StartDate && taskCurrent.EndDate < taskNext.StartDate.Value.Date)
        //                        {
        //                            accountResponses.Add(mapper.Map<AccountResponse>(account));
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return accountResponses;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<List<AccountCharacteRespones>> CheckForCharactersWithDuplicateCosplayers(string accountId, List<string> characters)
        //{
        //    List<AccountCharacteRespones> accountCharacteRespones = new List<AccountCharacteRespones>();
        //    Account account = await accountRepository.GetAccountIncludeAccountCategory(accountId);

        //    if (account == null)
        //    {
        //        return new List<AccountCharacteRespones>();
        //    }

        //    foreach (var character in characters)
        //    {
        //        Character checkCharacter = await characterRepository.GetCharacter(character);
        //        if (checkCharacter == null)
        //        {
        //            return new List<AccountCharacteRespones>();
        //        }
        //        if (checkCharacter == null) continue;

        //        var accountCategoryResponse = new AccountCharacteRespones
        //        {
        //            CharacterId = checkCharacter.CharacterId,
        //            Duplicate = !account.AccountCategories.Any(ac => ac.CategoryId.Equals(checkCharacter.CategoryId))
        //        };
        //        accountCharacteRespones.Add(accountCategoryResponse);
        //    }

        //    return accountCharacteRespones;
        //}

        //public async Task<List<AccountCategoryResponse>> GetListAccountToContactByContractId(string contractId)
        //{
        //    CCSS_Repository.Entities.Contract contract = await contractRespository.GetContractById(contractId);

        //    List<Account> accounts = new List<Account>();
        //    List<AccountResponse> accountResponses = new List<AccountResponse>();
        //    List<AccountCategoryResponse> accountCategoryResponses = new List<AccountCategoryResponse>();

        //    List<Task> tasks = new List<Task>();
        //    if (contract == null)
        //    {
        //        return new List<AccountCategoryResponse>();
        //    }
        //    if (contract.ContractCharacters != null)
        //    {
        //        foreach (var contractCharacter in (List<ContractCharacter>)contract.ContractCharacters)
        //        {
        //            Character character = await characterRepository.GetCharacter(contractCharacter.CharacterId);
        //            if (character != null)
        //            {
        //                accounts = await accountRepository.GetAccountByCategoryId(character.CategoryId, null);
        //                if (accounts == null)
        //                {
        //                    return new List<AccountCategoryResponse>();
        //                }
        //                foreach (var account in accounts)
        //                {
        //                    tasks = await taskRepository.GetTaskByAccountId(account.AccountId);
        //                    if (!tasks.Any())
        //                    {
        //                        accountResponses.Add(mapper.Map<AccountResponse>(account));
        //                    }
        //                    if (tasks.Any())
        //                    {
        //                        for (int i = 0; i < tasks.Count - 1; i++)
        //                        {
        //                            Task task = tasks[i];
        //                            Task taskNext = tasks[i + 1];
        //                            if (taskNext == null)
        //                            {
        //                                break;
        //                            }
        //                            if (task.StartDate.HasValue && task.EndDate.HasValue && taskNext.StartDate.HasValue && taskNext.EndDate.HasValue)
        //                            {
        //                                if (task.EndDate.Value.Date < contract.StartDate.Date && contract.EndDate.Date < taskNext.StartDate.Value.Date)
        //                                {
        //                                    accountResponses.Add(mapper.Map<AccountResponse>(account));
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                AccountCategoryResponse accountCategoryResponse = new AccountCategoryResponse()
        //                {
        //                    CategoryId = character.CategoryId,
        //                    CategoryName = character.Category.CategoryName,
        //                    Description = character.Category.Description,
        //                    CharacterId = character.CharacterId,
        //                    Character = character.CharacterName,
        //                    AccountResponses = accountResponses
        //                };
        //                accountCategoryResponses.Add(accountCategoryResponse);
        //                accountResponses = new List<AccountResponse>();
        //            }
        //        }
        //    }
        //    return accountCategoryResponses;
        //}

        //public async Task<bool> ChangeAccountForTask(string taskId, string accountId)
        //{
        //    try
        //    {
        //        Account account = await accountRepository.GetAccountByAccountId(accountId);
        //        Task task = await taskRepository.GetTask(taskId);

        //        if (task == null || account == null)
        //        {
        //            throw new Exception("Task or account does not exist");
        //        }

        //        task.AccountId = account.AccountId;

        //        bool result = await taskRepository.UpdateTask(task);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<AccountLoginResponse> Login(string email, string password)
        {
            try
            {
                var account = await accountRepository.GetAccountByEmailAndPassword(email, PasswordHash.ConvertToEncrypt(password));
                if (account == null)
                {
                    throw new Exception("Email or password wrong");
                }

                if ((bool)!account.IsActive)
                {
                    throw new Exception("Account has not been activated");
                }

                var jti = Guid.NewGuid().ToString();
                var jwtHandler = new JwtSecurityTokenHandler();
                var issuer = _configuration["AppSettings:Issuer"];
                var audience = _configuration["AppSettings:Audience"];

                var key = Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"]);

                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", account.AccountId),
                new Claim("Email", account.Email),
                new Claim("AccountName", account.Name),
                new Claim(ClaimTypes.Role, account.Role.RoleName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var jwtToken = jwtHandler.CreateToken(tokenDes);
                Console.WriteLine(SecurityAlgorithms.HmacSha256);

                string refreshTokenValue = GenerateRefreshToken();
                RefreshToken refreshToken = new RefreshToken
                {
                    RefreshTokenId = Guid.NewGuid().ToString(),
                    AccountId = account.AccountId,
                    CreateAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(7),
                    IsUsed = false,
                    RefreshTokenValue = refreshTokenValue,
                    JwtId = jti,
                    IsRevoked = false
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
                    RefreshToken = refreshTokenValue
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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

        private string GenerateCode(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string code = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return code;
        }

        public async Task<string> Register(AccountRequest accountRequest)
        {
            if (string.IsNullOrEmpty(accountRequest.Email) || string.IsNullOrEmpty(accountRequest.Password))
            {
                return "Email and password cannot null!!!";
            }
            var checkEmail = await accountRepository.GetAccountByEmail(accountRequest.Email);
            if (checkEmail != null)
            {
                return "Email existed!!!";
            }
            else
            {
                DateTime date;

                string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

                if (DateTime.TryParseExact(accountRequest.Birthday, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Ngày hợp lệ: " + date.ToString("yyyy-MM-dd"));
                }
                else
                {
                    Console.WriteLine("Không thể chuyển đổi chuỗi thành DateTime.");
                }

                Account account = new Account();

                account.AccountId = Guid.NewGuid().ToString();
                account.Name = accountRequest.Name;
                account.Email = accountRequest.Email;
                account.Description = accountRequest.Description;
                account.IsActive = false;
                account.Code = GenerateCode();
                account.Password = PasswordHash.ConvertToEncrypt(accountRequest.Password);
                account.Birthday = date;
                account.Phone = accountRequest.Phone;
                account.RoleId = "R005";


                bool result = await accountRepository.AddAccount(account);
                if (!result)
                {
                    return "Cannot save account";
                }
                SendMail _sendMail = new SendMail();
                await _sendMail.SendAccountVerificationEmail(account.Email, account.Code);
                return "Please enter code";
            }
        }

        public async Task<string> CodeValidation(string email, string code)
        {
            var checkAccount = await accountRepository.GetAccountByEmailAndCode(email, code);
            if (checkAccount == null)
            {
                throw new Exception("Code does not exist");
            }
            else
            {
                checkAccount.IsActive = true;
                bool result = await accountRepository.UpdateAccount(checkAccount);
                if (!result)
                {
                    return "Can not save account";
                }
                return "Success";
            }
        }

        public async Task<AccountResponse> GetAccountByAccountId(string accountId)
        {
            Account account = await accountRepository.GetAccountByAccountId(accountId);
            if (account == null)
            {
                return null;
            }
            return mapper.Map<AccountResponse>(account);
        }

        public async Task<bool> UpdateAccountByAccountId(string accountId, UpdateAccountRequest updateAccountRequest)
        {
            Account checkAccount = await accountRepository.GetAccountByAccountId(accountId);
            if (checkAccount == null)
            {
                return false;
            }
            mapper.Map(updateAccountRequest, checkAccount);

            checkAccount.Password = PasswordHash.ConvertToDecrypt(checkAccount.Password);

            bool result = await accountRepository.UpdateAccount(checkAccount);
            return result;  
        }

        public async Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDate(string characterId, string startDate, string endDate)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();

                Character character = await characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Character does not exist");
                }

                List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character);

                string format = "HH:mm dd/MM/yyyy"; 
                CultureInfo culture = CultureInfo.InvariantCulture;

                DateTime start = DateTime.ParseExact(startDate, format, culture);
                DateTime end = DateTime.ParseExact(endDate, format, culture);

                if(start > end)
                {
                    throw new Exception("Start can not greater than EndDate");
                }

                foreach (Account account in accounts)
                {
                    bool result = await taskRepository.CheckTaskIsValid(account, start, end);
                    if (result)
                    {
                        AccountByCharacterAndDateResponse accountRespose = mapper.Map<AccountByCharacterAndDateResponse>(account);
                        accountByCharacterAndDateResponses.Add(accountRespose); 
                    }
                }

                return accountByCharacterAndDateResponses;  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountByCharacterAndDateResponse>> ViewAllAccountByCharacterName(string characterName, string? start, string? end)
        {
            List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();

            Character character = await characterRepository.GetCharacterByCharacterName(characterName);
            if (character == null)
            {
                throw new Exception("Character not found!");
            }
            List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character);

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                string format = "HH:mm dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;

                try
                {
                    DateTime startDate = DateTime.ParseExact(start, format, culture);
                    DateTime endDate = DateTime.ParseExact(end, format, culture);

                    if (startDate > endDate)
                    {
                        throw new Exception("Start date cannot be greater than end date.");
                    }

                    foreach (Account account in accounts)
                    {
                        bool result = await taskRepository.CheckTaskIsValid(account, startDate, endDate);
                        if (result)
                        {
                            // Map và thêm vào danh sách kết quả
                            AccountByCharacterAndDateResponse accountResponse = mapper.Map<AccountByCharacterAndDateResponse>(account);
                            accountByCharacterAndDateResponses.Add(accountResponse);
                        }
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("Invalid date format. Please use 'HH:mm dd/MM/yyyy'.");
                }
            }
            else
            {
                accountByCharacterAndDateResponses = mapper.Map<List<AccountByCharacterAndDateResponse>>(accounts);
            }

            return accountByCharacterAndDateResponses;
        }

    }
}
