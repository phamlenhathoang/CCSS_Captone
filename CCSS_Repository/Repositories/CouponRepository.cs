using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICouponRepository
    {
        Task<List<Coupon>> GetAllCoupon(string? searchterm);
        Task<Coupon> GetCouponById(string couponId);
        Task<bool> AddCoupon(Coupon coupon);
        Task<bool> UpdateCoupon(Coupon coupon);
        Task<bool> RemoveCoupon(Coupon coupon);
    }
    public class CouponRepository: ICouponRepository
    {
        private readonly CCSSDbContext _context;

        public CouponRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coupon>> GetAllCoupon(string? searchterm)
        {
            if (string.IsNullOrWhiteSpace(searchterm))
            {
                return await _context.Coupons.OrderByDescending(c => c.StartDate).ToListAsync();
            }
            return await _context.Coupons.Where(sc => sc.CouponName.Equals(searchterm)).OrderByDescending(c => c.StartDate).ToListAsync();
        }

        public async Task<Coupon> GetCouponById(string couponId)
        {
            return await _context.Coupons.FirstOrDefaultAsync(sc => sc.CouponId.Equals(couponId));
        }

        public async Task<bool> AddCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCoupon(Coupon coupon)
        {
            _context.Coupons.Remove(coupon);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
