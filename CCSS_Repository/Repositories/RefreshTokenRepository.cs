using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<bool> AddRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetRefreshToken(string refreshTokenValue);
        Task<bool> RemoveRefreshTokenAsync(RefreshToken refreshToken);
    }
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly CCSSDbContext _context;

        public RefreshTokenRepository(CCSSDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRefreshToken(RefreshToken refreshToken)
        {
            await _context.AddAsync(refreshToken);
            int result = await _context.SaveChangesAsync();
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public async Task<RefreshToken> GetRefreshToken(string refreshTokenValue)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(r => r.RefreshTokenValue.Equals(refreshTokenValue));
        }

        public async Task<bool> RemoveRefreshTokenAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
            return await _context.SaveChangesAsync() > 0 ? true : false;  
        }
    }
}
