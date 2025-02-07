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
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            this.accountRepository = accountRepository;
            this._configuration = configuration;
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
                return jwtHandler.WriteToken(jwtToken);
            }
        }
    }
}


   