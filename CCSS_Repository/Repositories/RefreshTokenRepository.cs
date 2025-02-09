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
        Task<bool> AddRefreshToken(RefreshToken token);
    }
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly CCSSDBContext context;

        public RefreshTokenRepository(CCSSDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            await context.RefreshTokens.AddAsync(token);
            int result = await context.SaveChangesAsync();
            if (result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
