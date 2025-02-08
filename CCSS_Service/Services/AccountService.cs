using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IAccountService
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string email, string password);   
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;    
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository)
        {
            this.accountRepository = accountRepository;
            this.refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
        }
        public async Task<string> Login(string email, string password)
        {
            var account = await accountRepository.GetAccount(email, password);
            if (account == null)
            {
                throw new ArgumentNullException("Email or password wrong");
            }
            else
            {
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
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = issuer,
                    Audience = audience, // Đảm bảo rằng giá trị này được lấy từ cấu hình
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };
                var jwtToken = jwtHandler.CreateToken(tokenDes);
                RefreshToken refreshToken = new RefreshToken
                {
                    AccountId = account.AccountId,
                    CreatedAt = DateTime.UtcNow,    
                    ExpiresAt = DateTime.UtcNow.AddHours(1),
                    IsUsed = false,
                    Token = jwtHandler.WriteToken(jwtToken),
                    RefreshTokenValue = null,
                };
                bool result = await refreshTokenRepository.AddRefreshToken(refreshToken);
                if (!result)
                {
                    throw new Exception("Cannot save refresh token !!!");
                }
                return jwtHandler.WriteToken(jwtToken);
            }
        }

        public async Task<string> Register(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Email and password cannot null!!!");
            }
            var checkEmail = await accountRepository.GetAccount(email, null);
            if (checkEmail != null)
            {
                throw new Exception("Email existed!!!");
            }
            else
            {

            }
        }
    }
}


   