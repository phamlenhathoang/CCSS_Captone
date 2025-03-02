using CCSS_Repository.Entities;
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
    }
}
