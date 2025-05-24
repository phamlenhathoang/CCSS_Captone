using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Model;
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
using Org.BouncyCastle.Asn1.Crmf;
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
using Contract = CCSS_Repository.Entities.Contract;
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
        Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDate(string characterId, List<Date> dates, string accountId);
        Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDateForCreateEvent(string characterId, List<Date> dates, string accountId);
        Task<List<AccountByCharacterAndDateResponse>> ViewAllAccountByCharacterName(string characterName, string? start, string? end);
        Task<List<AccountByCharacterAndDateResponse>> ViewAllCosplayerByContractId(string contractId);
        Task<List<AccountResponse>> GetAllAccountByRoleId(string roleId);
        Task<bool> AddCosplayer(string userName, string password);
        Task<AccountLoginResponse> LoginByGoogle(string email, string googleId);
        Task<AccountResponse> GetAccountByEventCharacterId(string eventCharacterId);
        Task<bool> ChangePassword(string email);
        Task<List<AccountResponse>> GetAllAccount(string searchterm, string role);
        Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDateAndRange(string characterId, List<Date> dates, string requestId);
        Task<List<AccountByCharacterAndDateResponse>> GetAccountByRequestId(string requestId);
        Task<string> UpdateStatusAccount(string accountId, bool IsActive);
    }
    public class AccountService : IAccountService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IContractRespository contractRespository;
        private readonly ICharacterRepository characterRepository;
        //private readonly ICategoryRepository categoryRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly ICartRepository _cartRepository;
        private readonly IBeginTransactionRepository _beginTransactionRepository;
        private readonly Image image;
        private readonly IAccountImageRepository accountImageRepository;
        private readonly IRequestDatesRepository requestDatesRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IRequestCharacterRepository requestCharacterRepository;

        public AccountService(ICartRepository cartRepository, IBeginTransactionRepository beginTransactionRepository, ITaskRepository taskRepository, IAccountRepository accountRepository, IMapper mapper, ICharacterRepository characterRepository, IContractRespository contractRepository, /*ICategoryRepository categoryRepository,*/ IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository, IEmailService emailService, Image image, IAccountImageRepository accountImageRepository, IRequestDatesRepository requestDatesRepository, IRequestRepository requestRepository, IRequestCharacterRepository requestCharacterRepository)
        {
            this.taskRepository = taskRepository;
            _beginTransactionRepository = beginTransactionRepository;
            _cartRepository = cartRepository;
            this.accountRepository = accountRepository;
            this.mapper = mapper;
            this.characterRepository = characterRepository;
            this.contractRespository = contractRepository;
            //this.categoryRepository = categoryRepository;
            _configuration = configuration;
            this.refreshTokenRepository = refreshTokenRepository;
            _emailService = emailService;
            this.image = image;
            this.accountImageRepository = accountImageRepository;
            this.requestDatesRepository = requestDatesRepository;
            this.requestRepository = requestRepository;
            this.requestCharacterRepository = requestCharacterRepository;
        }

        #region GetAccountByEventCharacterId
        public async Task<AccountResponse> GetAccountByEventCharacterId(string eventCharacterId)
        {
            try
            {
                var account = await accountRepository.GetAccountByEventCharacterId(eventCharacterId);
                return mapper.Map<AccountResponse>(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving account: {ex.Message}");
            }
        }
        #endregion

        #region GetAllAccount
        public async Task<List<AccountResponse>> GetAllAccount(string? searchterm, string role)
        {
            List<AccountResponse> listAccount = new List<AccountResponse>();
            var account = await accountRepository.GetAllAccount(searchterm, role);
            foreach (var item in account)
            {
                AccountResponse accountResponse = new AccountResponse()
                {
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Email = item.Email,
                    Password = item.Password,
                    AverageStar = item.AverageStar,
                    Description = item.Description,
                    Birthday = item.Birthday?.ToString("dd/MM/yyyy"),
                    Phone = string.IsNullOrEmpty(item.Phone) ? null : int.Parse(item.Phone),
                    IsActive = item.IsActive,
                    OnTask = item.OnTask,
                    Leader = item.Leader,
                    Code = item.Code,
                    TaskQuantity = item.TaskQuantity,
                    Height = item.Height,
                    Weight = item.Weight,
                    SalaryIndex = item.SalaryIndex,
                    Images = item.AccountImages.Select(img => new AccountImageResponse
                    {
                        AccountImageId = img.AccountImageId,
                        UrlImage = img.UrlImage,
                        CreateDate = img.CreateDate?.ToString("dd/MM/yyyy"),
                        UpdateDate = img.UpdateDate?.ToString("dd/MM/yyyy"),
                        IsAvatar = img.IsAvatar,
                    }).ToList(),
                };
                listAccount.Add(accountResponse);
            }
            return listAccount;
        }

        #endregion

        #region Login
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

                if ((bool)account.IsLock)
                {
                    throw new Exception("This account locked");
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
                    Expires = DateTime.UtcNow.AddDays(7),
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
        #endregion

        #region LoginByGoogle
        public async Task<AccountLoginResponse> LoginByGoogle(string email, string googleId)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                try
                {
                    var account = await accountRepository.GetAccountByGoogleId(email, googleId);
                    if (account == null)
                    {
                        Account NewAccount = new Account()
                        {
                            AccountId = Guid.NewGuid().ToString(),
                            Email = email,
                            GoogleId = googleId,
                            RoleId = "R005",
                            UserName = email,
                            Name = email.Split("@")[0],
                            IsActive = true,
                        };
                        var resultAccount = await accountRepository.AddAccount(NewAccount);
                        if (!resultAccount)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("Add Failed");
                        }

                    }
                    else if ((bool)!account.IsActive)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Account has not been activated");
                    }



                    var jti = Guid.NewGuid().ToString();
                    var jwtHandler = new JwtSecurityTokenHandler();
                    var issuer = _configuration["AppSettings:Issuer"];
                    var audience = _configuration["AppSettings:Audience"];

                    var key = Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"]);
                    var googleAccount = await accountRepository.GetAccountByGoogleId(email, googleId);
                    var tokenDes = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("Id", googleAccount.AccountId),
                    new Claim("Email", googleAccount.Email),
                    new Claim("AccountName", googleAccount.Name),
                    new Claim(ClaimTypes.Role, googleAccount.Role.RoleName.ToString()),
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
                        AccountId = googleAccount.AccountId,
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
                        await transaction.RollbackAsync();
                        throw new Exception("Cannot save refresh token !!!");
                    }

                    await transaction.CommitAsync();
                    string accessToken = jwtHandler.WriteToken(jwtToken);
                    return new AccountLoginResponse
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshTokenValue
                    };
                }

                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine("Error: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region GenerateRefreshToken and GenerateCode
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
        #endregion

        #region Register
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

                using (var transaction = await _beginTransactionRepository.BeginTransaction())
                {
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
                    account.IsLock = false;

                    bool result = await accountRepository.AddAccount(account);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Cannot save account";
                    }

                    Cart cart = new Cart()
                    {
                        CartId = Guid.NewGuid().ToString(),
                        AccountId = account.AccountId,
                        TotalPrice = 0,
                        CreateDate = DateTime.Now,
                        UpdateDate = null,
                    };
                    var result1 = await _cartRepository.AddCart(cart);
                    if (!result1)
                    {
                        await transaction.RollbackAsync();
                        return "Add Cart failed";
                    }


                    SendMail _sendMail = new SendMail();
                    await _sendMail.SendAccountVerificationEmail(account.Email, account.Code);

                    await transaction.CommitAsync();
                    return "Please enter code";
                }
            }
        }
        #endregion

        #region CodeValidation
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

        #endregion

        #region GetAccountByAccountId
        public async Task<AccountResponse> GetAccountByAccountId(string accountId)
        {
            Account account = await accountRepository.GetAccountByAccountId(accountId);
            if (account == null)
            {
                return null;
            }

            var accountResponse = mapper.Map<AccountResponse>(account);


            accountResponse.Images ??= new List<AccountImageResponse>();

            if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
            {
                foreach (var image in account.AccountImages)
                {
                    accountResponse.Images.Add(new AccountImageResponse
                    {
                        AccountImageId = image.AccountImageId,
                        UrlImage = image.UrlImage,
                        CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                        IsAvatar = image.IsAvatar
                    });
                }
            }

            return accountResponse;
        }

        #endregion

        #region UpdateAccountByAccountId
        public async Task<bool> UpdateAccountByAccountId(string accountId, UpdateAccountRequest updateAccountRequest)
        {
            try
            {
                Account checkAccount = await accountRepository.GetAccountByAccountId(accountId);
                if (checkAccount == null)
                {
                    return false;
                }
                //mapper.Map(updateAccountRequest, checkAccount);

                DateTime date;

                string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

                if (DateTime.TryParseExact(updateAccountRequest.Birthday, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Ngày hợp lệ: " + date.ToString("yyyy-MM-dd"));
                }
                else
                {
                    Console.WriteLine("Không thể chuyển đổi chuỗi thành DateTime.");
                }

                checkAccount.Password = PasswordHash.ConvertToEncrypt(checkAccount.Password);
                checkAccount.Height = updateAccountRequest.Height;
                checkAccount.Birthday = date;
                checkAccount.Description = updateAccountRequest.Description;
                checkAccount.Name = updateAccountRequest.Name;
                checkAccount.UserName = updateAccountRequest.UserName;
                checkAccount.Email = updateAccountRequest.Email;
                checkAccount.Phone = updateAccountRequest.Phone;
                checkAccount.Weight = updateAccountRequest.Weight;

                bool checkUpdate = await accountRepository.UpdateAccount(checkAccount);
                if (!checkUpdate)
                {
                    throw new Exception("Can not update account");
                }

                List<AccountImage> accountImages = new List<AccountImage>();

                AccountImage avatar = new AccountImage()
                {
                    AccountId = checkAccount.AccountId,
                    CreateDate = DateTime.Now,
                    IsAvatar = true,
                    UrlImage = await image.UploadImageToFirebase(updateAccountRequest.Avatar),
                };

                accountImages.Add(avatar);

                if (updateAccountRequest.Images != null)
                {
                    foreach (var im in updateAccountRequest.Images)
                    {
                        AccountImage accountImage = new AccountImage()
                        {
                            AccountId = checkAccount.AccountId,
                            CreateDate = DateTime.Now,
                            IsAvatar = false,
                            UrlImage = await image.UploadImageToFirebase(im),
                        };

                        accountImages.Add(accountImage);
                    }
                }

                bool result = await accountImageRepository.AddListAccountImage(accountImages);
                if (!result)
                {
                    throw new Exception("Can not add AccountImages");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetAccountByCharacterAndDate
        public async Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDate(string characterId, List<Date> dates, string accountId)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();

                Character character = await characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Character does not exist");
                }

                List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character, accountId);

                string format = "HH:mm dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;
                List<DateRepo> dateRepos = new List<DateRepo>();
                foreach (var date in dates)
                {
                    DateTime start = DateTime.ParseExact(date.StartDate, format, culture);
                    DateTime end = DateTime.ParseExact(date.EndDate, format, culture);

                    if (start > end)
                    {
                        throw new Exception("Start can not greater than EndDate");
                    }

                    DateRepo dateRepo = new DateRepo()
                    {
                        StartDate = start,
                        EndDate = end,
                    };
                    dateRepos.Add(dateRepo);
                }

                foreach (Account account in accounts)
                {
                    bool result = await taskRepository.CheckTaskIsValid(account, dateRepos);
                    if (result)
                    {
                        AccountByCharacterAndDateResponse accountRespose = mapper.Map<AccountByCharacterAndDateResponse>(account);
                        accountRespose.Images ??= new List<AccountImageResponse>();

                        if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                        {
                            foreach (var image in account.AccountImages)
                            {
                                accountRespose.Images.Add(new AccountImageResponse
                                {
                                    AccountImageId = image.AccountImageId,
                                    UrlImage = image.UrlImage,
                                    CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    IsAvatar = image.IsAvatar
                                });
                            }
                        }
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
        #endregion

        #region ViewAllAccountByCharacterName
        public async Task<List<AccountByCharacterAndDateResponse>> ViewAllAccountByCharacterName(string characterName, string? start, string? end)
        {
            List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();

            Character character = await characterRepository.GetCharacterByCharacterName(characterName);
            if (character == null)
            {
                throw new Exception("Character not found!");
            }
            List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character, null);

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

                    //foreach (Account account in accounts)
                    //{
                    //    bool result = await taskRepository.CheckTaskIsValid(account, startDate, endDate);
                    //    if (result)
                    //    {
                    //        // Map và thêm vào danh sách kết quả
                    //        AccountByCharacterAndDateResponse accountResponse = mapper.Map<AccountByCharacterAndDateResponse>(account);
                    //        accountResponse.Images ??= new List<AccountImageResponse>();

                    //        if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                    //        {
                    //            foreach (var image in account.AccountImages)
                    //            {
                    //                accountResponse.Images.Add(new AccountImageResponse
                    //                {
                    //                    AccountImageId = image.AccountImageId,
                    //                    UrlImage = image.UrlImage,
                    //                    CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                    //                    UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                    //                    IsAvatar = image.IsAvatar
                    //                });
                    //            }
                    //        }
                    //        accountByCharacterAndDateResponses.Add(accountResponse);
                    //    }
                    //}
                }
                catch (FormatException)
                {
                    throw new Exception("Invalid date format. Please use 'HH:mm dd/MM/yyyy'.");
                }
            }
            else
            {
                foreach (Account account in accounts)
                {
                    AccountByCharacterAndDateResponse accountResponse = mapper.Map<AccountByCharacterAndDateResponse>(account);
                    accountResponse.Images ??= new List<AccountImageResponse>();

                    if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                    {
                        foreach (var image in account.AccountImages)
                        {
                            accountResponse.Images.Add(new AccountImageResponse
                            {
                                AccountImageId = image.AccountImageId,
                                UrlImage = image.UrlImage,
                                CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                IsAvatar = image.IsAvatar
                            });
                        }
                    }
                    accountByCharacterAndDateResponses.Add(accountResponse);

                }
            }

            return accountByCharacterAndDateResponses;
        }
        #endregion

        #region ViewAllCosplayerByContractId
        public async Task<List<AccountByCharacterAndDateResponse>> ViewAllCosplayerByContractId(string contractId)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> list = new List<AccountByCharacterAndDateResponse>();
                Contract contract = await contractRespository.GetContractById(contractId);

                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if (!contract.ContractCharacters.Any())
                {
                    throw new Exception("ContractCharacters do not exist");
                }

                foreach (var contractCharacter in contract.ContractCharacters)
                {
                    if (contractCharacter.CosplayerId != null)
                    {
                        Account account = await accountRepository.GetAccount(contractCharacter.CosplayerId);
                        if (account == null)
                        {
                            throw new Exception("Account does not exist");
                        }

                        AccountByCharacterAndDateResponse accountByCharacterAndDateResponse = mapper.Map<AccountByCharacterAndDateResponse>(account);

                        accountByCharacterAndDateResponse.Images ??= new List<AccountImageResponse>();

                        if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                        {
                            foreach (var image in account.AccountImages)
                            {
                                accountByCharacterAndDateResponse.Images.Add(new AccountImageResponse
                                {
                                    AccountImageId = image.AccountImageId,
                                    UrlImage = image.UrlImage,
                                    CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    IsAvatar = image.IsAvatar
                                });
                            }
                        }

                        list.Add(accountByCharacterAndDateResponse);
                    }

                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetAllAccountByRoleId
        public async Task<List<AccountResponse>> GetAllAccountByRoleId(string roleId)
        {
            List<AccountResponse> accountResponses = new List<AccountResponse>();
            var accounts = await accountRepository.GetAllAccountsByRoleId(roleId);
            foreach (Account account in accounts)
            {
                AccountResponse accountResponse = mapper.Map<AccountResponse>(account);
                accountResponse.Images ??= new List<AccountImageResponse>();

                if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                {
                    foreach (var image in account.AccountImages)
                    {
                        accountResponse.Images.Add(new AccountImageResponse
                        {
                            AccountImageId = image.AccountImageId,
                            UrlImage = image.UrlImage,
                            CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                            UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                            IsAvatar = image.IsAvatar
                        });
                    }
                }
                accountResponses.Add(accountResponse);
            }
            return accountResponses;
        }
        #endregion

        #region AddCosplayer
        public async Task<bool> AddCosplayer(string userName, string password)
        {
            try
            {
                Account checkUsername = await accountRepository.GetAccountByUsername(userName);
                if (checkUsername != null)
                {
                    throw new Exception("Username do exist");
                }

                Account account = new Account()
                {
                    UserName = userName,
                    Password = PasswordHash.ConvertToEncrypt(password),
                    IsActive = true,
                    RoleId = "R004"
                };

                bool result = await accountRepository.AddAccount(account);
                if (!result)
                {
                    throw new Exception("Can not add cosplayer");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ChangePassword
        public async Task<bool> ChangePassword(string email)
        {
            try
            {
                SendMail sendMail = new SendMail();
                Account account = await accountRepository.GetAccountByEmail(email);
                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }

                account.Password = PasswordHash.ConvertToEncrypt("123456");
                bool result = await accountRepository.UpdateAccount(account);
                if (result)
                {
                    await sendMail.SendPasswordChangePassword(account.Email);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetAccountByCharacterAndDateForCreateEvent
        public async Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDateForCreateEvent(string characterId, List<Date> dates, string accountId)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();

                Character character = await characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Character does not exist");
                }

                List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character, accountId);

                string format = "HH:mm dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;

                List<DateRepo> dateRepos = new List<DateRepo>();

                foreach (var date in dates)
                {
                    DateTime start = DateTime.ParseExact(date.StartDate, format, culture);
                    DateTime end = DateTime.ParseExact(date.EndDate, format, culture);

                    if (start > end)
                    {
                        throw new Exception("Start can not greater than EndDate");
                    }

                    DateRepo dateRepo = new DateRepo()
                    {
                        StartDate = start,
                        EndDate = end,
                    };
                    dateRepos.Add(dateRepo);
                }

                foreach (Account account in accounts)
                {
                    bool result = await taskRepository.CheckTaskIsValid(account, dateRepos);
                    bool resultRequetDate = await requestDatesRepository.CheckValidRequestDate(account, dateRepos);

                    if (result && resultRequetDate)
                    {
                        AccountByCharacterAndDateResponse accountRespose = mapper.Map<AccountByCharacterAndDateResponse>(account);
                        accountRespose.Images ??= new List<AccountImageResponse>();

                        if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                        {
                            foreach (var image in account.AccountImages)
                            {
                                accountRespose.Images.Add(new AccountImageResponse
                                {
                                    AccountImageId = image.AccountImageId,
                                    UrlImage = image.UrlImage,
                                    CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    IsAvatar = image.IsAvatar
                                });
                            }
                        }
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
        #endregion

        #region GetAccountByCharacterAndDateAndRange
        public async Task<List<AccountByCharacterAndDateResponse>> GetAccountByCharacterAndDateAndRange(string characterId, List<Date> dates, string requestId)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();
                Request request = await requestRepository.GetRequestById(requestId);

                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }
                if (request.ServiceId != "S003")
                {
                    throw new Exception("Service of this request must be S003");
                }
                if (request.Range == null)
                {
                    throw new Exception("Range of this request can not null");
                }

                string[] parts = request.Range.Split(' ')[0].Split('-');

                int minSalary = int.Parse(parts[0]); // 15000
                int maxSalary = int.Parse(parts[1]);

                Character character = await characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Character does not exist");
                }

                List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character, minSalary, maxSalary);

                string format = "HH:mm dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;

                List<DateRepo> dateRepos = new List<DateRepo>();

                foreach (var date in dates)
                {
                    DateTime start = DateTime.ParseExact(date.StartDate, format, culture);
                    DateTime end = DateTime.ParseExact(date.EndDate, format, culture);

                    if (start > end)
                    {
                        throw new Exception("Start can not greater than EndDate");
                    }

                    DateRepo dateRepo = new DateRepo()
                    {
                        StartDate = start,
                        EndDate = end,
                    };
                    dateRepos.Add(dateRepo);
                }

                foreach (Account account in accounts)
                {
                    bool result = await taskRepository.CheckTaskIsValid(account, dateRepos);
                    bool resultRequetDate = await requestDatesRepository.CheckValidRequestDate(account, dateRepos);

                    if (result && resultRequetDate)
                    {
                        AccountByCharacterAndDateResponse accountRespose = mapper.Map<AccountByCharacterAndDateResponse>(account);
                        accountRespose.Images ??= new List<AccountImageResponse>();

                        if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                        {
                            foreach (var image in account.AccountImages)
                            {
                                accountRespose.Images.Add(new AccountImageResponse
                                {
                                    AccountImageId = image.AccountImageId,
                                    UrlImage = image.UrlImage,
                                    CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                    IsAvatar = image.IsAvatar
                                });
                            }
                        }
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
        #endregion

        #region UpdateStatusAccount
        public async Task<string> UpdateStatusAccount(string accountId, bool IsActive)
        {
            var account = await accountRepository.GetAccountByAccountIdNotActive(accountId);
            if (account == null)
            {
                return "Account not found";
            }
            account.IsActive = IsActive;

            var result = await accountRepository.UpdateAccount(account);
            return result ? "Update Success" : "Update Failed";
        }
        #endregion

        public async Task<List<AccountByCharacterAndDateResponse>> GetAccountByRequestId(string requestId)
        {
            try
            {
                List<AccountByCharacterAndDateResponse> accountByCharacterAndDateResponses = new List<AccountByCharacterAndDateResponse>();
                Request request = await requestRepository.GetRequestById(requestId);
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }

                string[] parts = request.Range.Split(' ')[0].Split('-');

                int minSalary = int.Parse(parts[0]); // 15000
                int maxSalary = int.Parse(parts[1]);

                foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                {
                    Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);
                    if (character == null)
                    {
                        throw new Exception("Character does not exist");
                    }

                    List<DateRepo> dateRepos = new List<DateRepo>();

                    foreach (RequestDate requestDate in requestCharacter.RequestDates)
                    {
                        DateRepo dateRepo = new DateRepo()
                        {
                            StartDate = requestDate.StartDate,
                            EndDate = requestDate.EndDate,
                        };
                        dateRepos.Add(dateRepo);
                    }

                    List<Account> accounts = await accountRepository.GetAllAccountsByCharacter(character, minSalary, maxSalary);

                    foreach (Account account in accounts)
                    {
                        bool result = await taskRepository.CheckTaskIsValid(account, dateRepos);
                        bool resultRequetDate = await requestDatesRepository.CheckValidRequestDate(account, dateRepos);

                        if (result && resultRequetDate)
                        {
                            AccountByCharacterAndDateResponse accountRespose = mapper.Map<AccountByCharacterAndDateResponse>(account);
                            accountRespose.Images ??= new List<AccountImageResponse>();

                            if (account.AccountImages?.Any() == true) // Kiểm tra danh sách có phần tử không
                            {
                                foreach (var image in account.AccountImages)
                                {
                                    accountRespose.Images.Add(new AccountImageResponse
                                    {
                                        AccountImageId = image.AccountImageId,
                                        UrlImage = image.UrlImage,
                                        CreateDate = image.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                                        UpdateDate = image.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                                        IsAvatar = image.IsAvatar
                                    });
                                }
                            }
                            accountByCharacterAndDateResponses.Add(accountRespose);
                        }
                    }

                }

                return accountByCharacterAndDateResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
