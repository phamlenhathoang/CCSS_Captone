using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICouponService
    {
        Task<List<CouponResponse>> GetAllCoupon(string? searchterm);
        Task<CouponResponse> GetCouponById(string couponId);
        Task<string> AddCoupon(CouponRequest couponRequest);
        Task<string> UpdateCoupon(string couponId, CouponRequest couponRequest);
        Task<string> DeleteCoupon(string couponId);
    }


    public class CouponService: ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IBeginTransactionRepository _transactionRepository;

        public CouponService(ICouponRepository couponRepository, IBeginTransactionRepository transactionRepository)
        {
            _couponRepository = couponRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<CouponResponse>> GetAllCoupon(string? searchterm)
        {
            List<CouponResponse> Listcoupon = new List<CouponResponse>();
            var coupons = await _couponRepository.GetAllCoupon(searchterm);
            foreach (var item in coupons)
            {
                var couponResponse = new CouponResponse()
                {
                    CouponId = item.CouponId,
                    CouponName = item.CouponName,
                    Condition = item.Condition,
                    Percent = item.Percent,
                    Amount = item.Amount,
                    StartDate = item.StartDate.ToString("HH:mm dd/MM/yyyy"),
                    EndDate = item.EndDate.ToString("HH:mm dd/MM/yyyy"),
                    Type = item.Type,
                };
                Listcoupon.Add(couponResponse);
            }
            return Listcoupon;
        }

        public async Task<CouponResponse> GetCouponById(string couponId)
        {
            var coupon = await _couponRepository.GetCouponById(couponId);

            var response = new CouponResponse()
            {
                CouponId = coupon.CouponId,
                CouponName = coupon.CouponName,
                Condition = coupon.Condition,
                Percent = coupon.Percent,
                Amount = coupon.Amount,
                StartDate = coupon.StartDate.ToString("HH:mm dd/MM/yyyy"),
                EndDate = coupon.EndDate.ToString("HH:mm dd/MM/yyyy"),
                Type = coupon.Type,
            };

            return response;

        }

        public async Task<string> AddCoupon(CouponRequest couponRequest)
        {
            using (var transaction = await _transactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(couponRequest.StartDate) || !string.IsNullOrEmpty(couponRequest.EndDate))
                {

                    string[] timeFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                    bool isValidStartTime = DateTime.TryParseExact(couponRequest.StartDate.Trim(), timeFormats,
                                                              System.Globalization.CultureInfo.InvariantCulture,
                                                              System.Globalization.DateTimeStyles.None, out StartDate);

                    bool isValidEndTime = DateTime.TryParseExact(couponRequest.EndDate.Trim(), timeFormats,
                                                                 System.Globalization.CultureInfo.InvariantCulture,
                                                                 System.Globalization.DateTimeStyles.None, out EndDate);
                    if (!isValidStartTime && !isValidEndTime)
                    {
                        await transaction.RollbackAsync();
                        return "Valid Time is wrong";
                    }
                }
                if (StartDate < DateTime.Now && EndDate < DateTime.Now)
                {
                    await transaction.RollbackAsync();
                    return "Start date and End Date cannot be in the past.";
                }
                if (StartDate >= EndDate)
                {
                    await transaction.RollbackAsync();
                    return "End date must be greater than start date.";
                }
                if (couponRequest == null)
                {
                    return "Please enter the field";
                }
                Coupon coupon = new Coupon()
                {
                    CouponId = Guid.NewGuid().ToString(),
                    CouponName = couponRequest.CouponName,
                    Condition = couponRequest.Condition,
                    Percent = couponRequest.Percent ,
                    Amount = couponRequest.Amount,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Type = CouponType.ForOrder,
                };
                var result = await _couponRepository.AddCoupon(coupon);

                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Create failed";
                }

                await transaction.CommitAsync();
                return "Create Success";
            }
        }

        public async Task<string> UpdateCoupon(string couponId, CouponRequest couponRequest)
        {
            using (var transaction = await _transactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(couponRequest.StartDate) || !string.IsNullOrEmpty(couponRequest.EndDate))
                {

                    string[] timeFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                    bool isValidStartTime = DateTime.TryParseExact(couponRequest.StartDate.Trim(), timeFormats,
                                                              System.Globalization.CultureInfo.InvariantCulture,
                                                              System.Globalization.DateTimeStyles.None, out StartDate);

                    bool isValidEndTime = DateTime.TryParseExact(couponRequest.EndDate.Trim(), timeFormats,
                                                                 System.Globalization.CultureInfo.InvariantCulture,
                                                                 System.Globalization.DateTimeStyles.None, out EndDate);
                    if (!isValidStartTime && !isValidEndTime)
                    {
                        await transaction.RollbackAsync();
                        return "Valid Time is wrong";
                    }
                }
                if (StartDate < DateTime.Now && EndDate < DateTime.Now)
                {
                    await transaction.RollbackAsync();
                    return "Start date and End Date cannot be in the past.";
                }
                if (StartDate >= EndDate)
                {
                    await transaction.RollbackAsync();
                    return "End date must be greater than start date.";
                }
                var couponExisting = await _couponRepository.GetCouponById(couponId);
                if (couponExisting == null)
                {
                    return "Coupon not found";
                }
                couponExisting.CouponName = couponRequest.CouponName;
                couponExisting.Condition = couponRequest.Condition;
                couponExisting.Percent = couponRequest.Percent;
                couponExisting.Amount = couponRequest.Amount;
                couponExisting.StartDate = StartDate;
                couponExisting.EndDate = EndDate;

                var result = await _couponRepository.UpdateCoupon(couponExisting);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Update failed";
                }

                await transaction.CommitAsync();
                return "Update Success";
            }
        }

        public async Task<string> DeleteCoupon(string couponId)
        {
            var coupon = await _couponRepository.GetCouponById(couponId);
            if (coupon == null)
            {
                return "Coupon not Found";
            }
            var result = await _couponRepository.RemoveCoupon(coupon);

            return result ? "Remove Success" : "Update Failed";
        }
    }
}
