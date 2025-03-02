using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public interface IRefreshTokenService
    {
        Task<RefreshTokenResponse> GetRefreshToken(TokenRequest tokenRequest);
    }
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IConfiguration _configuration;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IConfiguration configuration, IAccountRepository accountRepository)
        {
            this.refreshTokenRepository = refreshTokenRepository;
            this.accountRepository = accountRepository;
            _configuration = configuration;
        }
        public async Task<RefreshTokenResponse> GetRefreshToken(TokenRequest tokenRequest)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var tokenValidateParam = GetTokenValidationParameters();

                var tokenInVerification = jwtTokenHandler.ValidateToken(tokenRequest.AccessToken, tokenValidateParam, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    Console.WriteLine("Algorithm (Validate): " + jwtSecurityToken.Header.Alg);
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    Console.WriteLine("Algorithm Match: " + result);

                    if (!result)
                    {
                        throw new Exception("Invalid token");
                    }
                }

                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)!.Value);
                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);

                if (expireDate > DateTime.UtcNow)
                {
                    throw new Exception("Access token has not yet expired");
                }

                var refreshToken = await refreshTokenRepository.GetRefreshToken(tokenRequest.RefreshToken!);

                if (refreshToken == null)
                {
                    throw new Exception("Refresh token does not exist");
                }

                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (refreshToken.JwtId != jti)
                {
                    throw new Exception("Token doesn't match");
                }

                if (await refreshTokenRepository.RemoveRefreshTokenAsync(refreshToken))
                {
                    var account = await accountRepository.GetAccountByAccountId(refreshToken.AccountId);
                    if (account != null)
                    {
                        return await GenerateAccessTokenAsync(account);
                        
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<RefreshTokenResponse> GenerateAccessTokenAsync(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }

            var jti = Guid.NewGuid().ToString();
            var jwtHandler = new JwtSecurityTokenHandler();

            var issuer = _configuration["AppSettings:Issuer"] ?? throw new InvalidOperationException("Issuer not configured");
            var audience = _configuration["AppSettings:Audience"] ?? throw new InvalidOperationException("Audience not configured");
            var secretKey = _configuration["AppSettings:SecretKey"] ?? throw new InvalidOperationException("SecretKey not configured");

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("Id", account.AccountId ?? string.Empty),
            new Claim("Email", account.Email ?? string.Empty),
            new Claim("AccountName", account.Name ?? string.Empty),
            new Claim(ClaimTypes.Role, account.Role?.RoleName.ToString() ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, jti)
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            var jwtToken = jwtHandler.CreateToken(tokenDescriptor);
            string refreshTokenValue = GenerateRefreshToken();

            var refreshToken = new RefreshToken
            {
                RefreshTokenId = Guid.NewGuid().ToString(),
                AccountId = account.AccountId ?? string.Empty,
                CreateAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsUsed = false,
                RefreshTokenValue = refreshTokenValue,
                JwtId = jti,
                IsRevoked = false,
            };

            bool result = await refreshTokenRepository.AddRefreshToken(refreshToken);
            if (!result)
            {
                throw new Exception("Cannot save refresh token");
            }

            string accessToken = jwtHandler.WriteToken(jwtToken);

            return new RefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
            };
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

        private TokenValidationParameters GetTokenValidationParameters()
        {
            var jwtSettings = _configuration.GetSection("AppSettings");

            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidAudience = jwtSettings["Audience"],
                ValidIssuer = jwtSettings["Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false //ko kiểm tra token hết hạn
            };
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}
