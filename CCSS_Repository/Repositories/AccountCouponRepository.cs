using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IAccountCouponRepository
    {
        Task<AccountCoupon> GetAccountCoupon(string id);
    }
    public class AccountCouponRepository : IAccountCouponRepository
    {
        private readonly CCSSDbContext dbContext;
        public AccountCouponRepository(CCSSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<AccountCoupon> GetAccountCoupon(string id)
        {
            return dbContext.AccountCoupons.Include(c => c.Coupon).FirstOrDefaultAsync(ac => ac.AccountCouponId.Equals(id));
        }
    }
}
