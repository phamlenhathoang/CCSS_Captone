using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Models;
using CCSS_Service.Models.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IAccountService
    {
        Task<string> Login(string email, string password);
        Task<string> Register(AccountLoginRequest accountLogin, string role);   
        Task<string> CodeValidation(string email, string code);
        Task<string> ForgotPassword(string email, string? newPassword, string? code); 
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;    
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository, IMapper mapper, IEmailService emailService)
        {
            this.accountRepository = accountRepository;
            this.refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<string> Login(string email, string password)
        {
            var account = await accountRepository.GetAccountByEmailAndPassword(email, BCrypt.Net.BCrypt.HashPassword(password));
            if (account == null)
            {
                return "Email or password wrong";
            }
            else
            {
                if (!account.IsActive)
                {
                    return "Account has not been activated";
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
                    RefreshToken refreshToken = new RefreshToken
                    {
                        RefreshTokenId = Guid.NewGuid().ToString(),
                        AccountId = account.AccountId,
                        CreatedAt = DateTime.UtcNow,
                        ExpiresAt = DateTime.UtcNow.AddHours(1),
                        IsUsed = false,
                        Token = jwtHandler.WriteToken(jwtToken),
                        RefreshTokenValue = null,
                        JwtId = jti,
                    };
                    bool result = await refreshTokenRepository.AddRefreshToken(refreshToken);
                    if (!result)
                    {
                       return "Cannot save refresh token !!!";
                    }
                    return jwtHandler.WriteToken(jwtToken);
                }
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

        public async Task<string> Register(AccountLoginRequest accountLogin, string role)
        {
            if (string.IsNullOrEmpty(accountLogin.Email) || string.IsNullOrEmpty(accountLogin.Password) || string.IsNullOrEmpty(role))
            {
                return "Email and password cannot null!!!";
            }
            var checkEmail = await accountRepository.GetAccountByEmail(accountLogin.Email);
            if (checkEmail != null)
            {
                return "Email existed!!!";
            }
            else
            {
                Account account = _mapper.Map<Account>(accountLogin);
                account.AccountId = Guid.NewGuid().ToString();  
                account.CreateDate = DateTime.UtcNow;
                account.IsActive = false;
                account.Code = GenerateCode();
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);  
                if (role.ToLower() == RoleEnum.Customer.ToString().ToLower()) 
                {
                    account.RoleId = "3";
                }
                else
                {
                    account.RoleId = "4";
                }
                bool result = await accountRepository.AddAcount(account);
                if (!result)
                {
                    return "Cannot save account";
                }
                await _emailService.SendEmailAsync(accountLogin.Email, "Confirm your account", $"Here is your code: {account.Code}. Please enter this code to authenticate your account.", true);
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
                bool result = await accountRepository.UpdateAcount(checkAccount);
                if (!result) 
                {
                    return "Can not save account";
                }
                return "Success";
            }
        }

        public async Task<string> ForgotPassword(string email, string? newPassword, string? code)
        {
            Account checkAccount;
            if (!string.IsNullOrEmpty(code))
            {
                checkAccount = await accountRepository.GetAccountByEmailAndCode(email, code);
                if(checkAccount == null)
                {
                    return "Code does not exist ";
                }
            }
            else
            {
                checkAccount = await accountRepository.GetAccountByEmail(email);
                if (checkAccount == null)
                {
                    return"Email does not exist ";
                }
            }
            if (string.IsNullOrEmpty(code))
            {
                checkAccount.Code = GenerateCode();
                bool result = await accountRepository.UpdateAcount(checkAccount);
                if (!result)
                {
                    return "Can not save account" ;
                }
                await _emailService.SendEmailAsync(email, "Confirm your account", $"Here is your code: {checkAccount.Code}. Please enter this code to authenticate your account.", true);
                return "Please enter code";
            }
            if (!string.IsNullOrEmpty(code) && string.IsNullOrEmpty(newPassword))
            {
                return "Please enter new password";
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                checkAccount.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                bool result = await accountRepository.UpdateAcount(checkAccount);
                if (!result)
                {
                    return "Can not save account";
                }
                return "Success";
            }
            return null;
        }

    }
}


   