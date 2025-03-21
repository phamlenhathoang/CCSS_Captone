using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CCSS_Repository.Entities;

namespace CCSS_Repository.Repositories
{
    public interface IAccountCouponRepository
    {
        Task<AccountCoupon> GetAccountCoupon(string id);
        Task<List<AccountCoupon>> GetAllAccountCoupons();
        Task<AccountCoupon> GetAccountCouponById(string accountCouponId);
        Task<bool> AddAccountCoupon(AccountCoupon accountCoupon);
        Task<bool> UpdateAccountCoupon(AccountCoupon accountCoupon);
        Task<bool> DeleteAccountCoupon(AccountCoupon accountCoupon);
    }

    public class AccountCouponRepository : IAccountCouponRepository
    {
        private readonly CCSSDbContext _dbContext;

        public AccountCouponRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountCoupon> GetAccountCoupon(string id)
        {
            return await _dbContext.AccountCoupons
                .Where(ac => ac.AccountCouponId == id)
                .Include(ac => ac.Coupon)
                .FirstOrDefaultAsync();
        }

        public async Task<AccountCoupon> GetAccountCouponById(string accountCouponId)
        {
            return await _dbContext.AccountCoupons.Include(c => c.Coupon).FirstOrDefaultAsync(sc => sc.AccountCouponId.Equals(accountCouponId));
        }

        public async Task<List<AccountCoupon>> GetAllAccountCoupons()
        {
            return await _dbContext.AccountCoupons
                .Include(ac => ac.Coupon)  // Nếu có quan hệ với Coupon
                .ToListAsync();
        }

        public async Task<bool> AddAccountCoupon(AccountCoupon accountCoupon)
        {
            await _dbContext.AccountCoupons.AddAsync(accountCoupon);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAccountCoupon(AccountCoupon accountCoupon)
        {
            _dbContext.AccountCoupons.Update(accountCoupon);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAccountCoupon(AccountCoupon accountCoupon)
        {
            _dbContext.AccountCoupons.Remove(accountCoupon);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
