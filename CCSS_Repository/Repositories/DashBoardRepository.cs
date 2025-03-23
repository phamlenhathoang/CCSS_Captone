using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Repository.Repositories
{
    public interface IDashBoardRepository
    {
        Task<List<Payment>> GetRevenue(DateFilterType filterType, RevenueSource revenueSource);
        Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus status, DateFilterType filterType);
        Task<List<Account>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<List<Feedback>> GetFeedbacksByContractDescriptionAsync();
        Task<List<Account>> Get5PopularCosplayers(DateFilterType filterType);
        Task<List<Account>> Get5FavoriteCosplayer(DateFilterType filterType);
    }

        public class DashBoardRepository : IDashBoardRepository
    {
        private readonly CCSSDbContext _context;
        public DashBoardRepository(CCSSDbContext cCSSDbContext)
        {
            _context = cCSSDbContext;
        }
        public async Task<List<Payment>> GetRevenue(DateFilterType filterType, RevenueSource revenueSource)
        {
            var now = DateTime.UtcNow;
            var query = _context.Payments
                .Where(p => p.Status == PaymentStatus.Complete) // PaymentStatus = 1
                .AsQueryable();

            // Lọc theo RevenueSource
            switch (revenueSource)
            {
                case RevenueSource.Order:
                    query = query.Where(p => p.Purpose == PaymentPurpose.Order);
                    break;
                case RevenueSource.festival:
                    query = query.Where(p => p.Purpose == PaymentPurpose.BuyTicket);
                    break;
                case RevenueSource.Service:
                    query = query.Where(p => p.Purpose == PaymentPurpose.contractSettlement);
                    break;
                case RevenueSource.Total:
                    query = query.Where(p => p.Purpose == PaymentPurpose.BuyTicket ||
                                             p.Purpose == PaymentPurpose.contractSettlement ||
                                             p.Purpose == PaymentPurpose.Order);
                    break;
            }

            // Lọc theo DateFilterType
            switch (filterType)
            {
                case DateFilterType.Today:
                    query = query.Where(p => p.CreatAt.HasValue &&
                                             p.CreatAt.Value.Date == now.Date);
                    break;
                case DateFilterType.ThisWeek:
                    var dayOfWeek = (int)now.DayOfWeek;
                    var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -dayOfWeek + 1); // Thứ Hai đầu tuần
                    var endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật cùng tuần
                    query = query.Where(p => p.CreatAt.HasValue &&
                                             p.CreatAt.Value.Date >= startOfWeek &&
                                             p.CreatAt.Value.Date <= endOfWeek);
                    break;
                case DateFilterType.ThisMonth:
                    query = query.Where(p => p.CreatAt.HasValue &&
                                             p.CreatAt.Value.Year == now.Year &&
                                             p.CreatAt.Value.Month == now.Month);
                    break;
                case DateFilterType.ThisYear:
                    query = query.Where(p => p.CreatAt.HasValue &&
                                             p.CreatAt.Value.Year == now.Year);
                    break;
            }

            return await query.ToListAsync();
        }


        public async Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus status, DateFilterType filterType)
        {
            var now = DateTime.UtcNow;
            var query = _context.Contracts
                .Where(c => c.ContractStatus == status && c.Request != null) // Đảm bảo có Request
                .AsQueryable();

            switch (filterType)
            {
                case DateFilterType.Today:
                    query = query.Where(c => c.Request.StartDate.Date == now.Date);
                    break;

                case DateFilterType.ThisWeek:
                    var dayOfWeek = (int)now.DayOfWeek;
                    var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -dayOfWeek + 1);
                    var endOfWeek = startOfWeek.AddDays(6);
                    query = query.Where(c => c.Request.StartDate.Date >= startOfWeek && c.Request.EndDate.Date <= endOfWeek);
                    break;

                case DateFilterType.ThisMonth:
                    query = query.Where(c => c.Request.StartDate.Year == now.Year && c.Request.StartDate.Month == now.Month);
                    break;

                case DateFilterType.ThisYear:
                    query = query.Where(c => c.Request.StartDate.Year == now.Year);
                    break;
            }

            return await query.ToListAsync();
        }


        public async Task<List<Account>> GetTop5AccountsWithMostPaymentsAsync()
        {
            int currentYear = DateTime.UtcNow.Year;

            return await _context.Accounts
                .Where(a => a.AccountCoupons.Any(ac =>
                    ac.Payment != null &&
                    ac.Payment.Status == PaymentStatus.Complete &&
                    ac.Payment.Purpose == PaymentPurpose.contractSettlement &&
                    ac.Payment.CreatAt.HasValue && ac.Payment.CreatAt.Value.Year == currentYear &&
                    ac.Payment.Contract != null && ac.Payment.Contract.ContractStatus == ContractStatus.Completed
                ))
                .OrderByDescending(a => a.AccountCoupons
                    .Where(ac => ac.Payment != null)
                    .Count(ac => ac.Payment.Status == PaymentStatus.Complete &&
                                 ac.Payment.Purpose == PaymentPurpose.contractSettlement &&
                                 ac.Payment.CreatAt.HasValue && ac.Payment.CreatAt.Value.Year == currentYear &&
                                 ac.Payment.Contract != null && ac.Payment.Contract.ContractStatus == ContractStatus.Completed
                    ))
                .Take(5)
                .Include(a => a.AccountImages) // Nạp thêm hình ảnh của Account
                .ToListAsync();
        }



        //public async Task<List<Feedback>> GetFeedbacksByContractDescriptionAsync()
        //{
        //    return await _context.Feedbacks
        //        .Where(f => f.Contract != null && (int?)f.Contract.Description == 1)
        //        .ToListAsync();
        //}
        //public async Task<List<Account>> Get5PopularCosplayers(DateFilterType filterType)
        //{
        //    DateTime startDate = filterType switch
        //    {
        //        DateFilterType.Today => DateTime.UtcNow.Date,
        //        DateFilterType.ThisWeek => DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek + 1).Date, // Đầu tuần (Thứ Hai)
        //        DateFilterType.ThisMonth => new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1), // Đầu tháng
        //        DateFilterType.ThisYear => new DateTime(DateTime.UtcNow.Year, 1, 1), // Đầu năm
        //        _ => DateTime.UtcNow.Date
        //    };

        //    return await _context.Accounts
        //        .Where(a => a.Role.RoleName == RoleName.Cosplayer &&
        //            a.ContractCharacter != null && // Kiểm tra có ContractCharacter không
        //            a.ContractCharacter.Contract.Status == ContractStatus.Completed &&
        //            a.ContractCharacter.Contract.Description == ContractDescription.RentCosplayer &&
        //            a.ContractCharacter.Contract.Payments.Any(p => p.Status == PaymentStatus.Complete &&
        //                                                           p.Purpose == PaymentPurpose.contractSettlement &&
        //                                                           p.CreatAt.HasValue && p.CreatAt.Value >= startDate))
        //        .OrderByDescending(a => a.Contracts.Count(c => c.Status == ContractStatus.Completed &&
        //                                                       c.Description == ContractDescription.RentCosplayer &&
        //                                                       c.Payments.Any(p => p.Status == PaymentStatus.Complete &&
        //                                                                           p.Purpose == PaymentPurpose.contractSettlement &&
        //                                                                           p.CreatAt.HasValue && p.CreatAt.Value >= startDate)))
        //        .Take(5)
        //        .ToListAsync();
        //}
        public async Task<List<Account>> Get5PopularCosplayers(DateFilterType filterType)
        {
            var now = DateTime.UtcNow;
            IQueryable<Account> query = _context.Accounts
                .Where(a => a.Role.RoleName == RoleName.Cosplayer);

            switch (filterType)
            {
                case DateFilterType.Today:
                    query = query.Where(a => _context.Tasks
                        .Any(t => t.AccountId == a.AccountId && t.StartDate.Value.Date == now.Date));
                    break;

                case DateFilterType.ThisWeek:
                    var dayOfWeek = (int)now.DayOfWeek;
                    var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -dayOfWeek + 1);
                    var endOfWeek = startOfWeek.AddDays(6);
                    query = query.Where(a => _context.Tasks
                        .Any(t => t.AccountId == a.AccountId &&
                                  t.StartDate.Value.Date >= startOfWeek &&
                                  t.StartDate.Value.Date <= endOfWeek));
                    break;

                case DateFilterType.ThisMonth:
                    query = query.Where(a => _context.Tasks
                        .Any(t => t.AccountId == a.AccountId &&
                                  t.StartDate.Value.Year == now.Year &&
                                  t.StartDate.Value.Month == now.Month));
                    break;

                case DateFilterType.ThisYear:
                    query = query.Where(a => _context.Tasks
                        .Any(t => t.AccountId == a.AccountId &&
                                  t.StartDate.Value.Year == now.Year));
                    break;
            }

            // Lấy số lượng nhiệm vụ đã hoàn thành cho từng cosplayer
            var taskCounts = await _context.Tasks
                .Where(t => t.Status == TaskStatus.Completed &&
                            t.EventCharacterId == null &&
                            t.ContractCharacterId != null)
                .GroupBy(t => t.AccountId)
                .Select(g => new { AccountId = g.Key, TaskCount = g.Count() })
                .ToListAsync();

            // Kết hợp danh sách cosplayer với số nhiệm vụ hoàn thành
            var cosplayers = await query.ToListAsync();
            var sortedCosplayers = cosplayers
                .Select(a => new
                {
                    Account = a,
                    TaskCount = taskCounts.FirstOrDefault(tc => tc.AccountId == a.AccountId)?.TaskCount ?? 0
                })
                .OrderByDescending(a => a.TaskCount)
                .Take(5)
                .Select(a => a.Account)
                .ToList();

            return sortedCosplayers;
        }
        public async Task<List<Account>> Get5FavoriteCosplayer(DateFilterType filterType)
        {
            var now = DateTime.UtcNow;
            IQueryable<Feedback> query = _context.Feedbacks;

            switch (filterType)
            {
                case DateFilterType.Today:
                    query = query.Where(f => f.CreateDate.Date == now.Date);
                    break;
                case DateFilterType.ThisWeek:
                    var startOfWeek = now.Date.AddDays(now.DayOfWeek == DayOfWeek.Sunday ? -6 : -(int)now.DayOfWeek + 1);
                    var endOfWeek = startOfWeek.AddDays(6);
                    query = query.Where(f => f.CreateDate.Date >= startOfWeek && f.CreateDate.Date <= endOfWeek);
                    break;
                case DateFilterType.ThisMonth:
                    query = query.Where(f => f.CreateDate.Year == now.Year && f.CreateDate.Month == now.Month);
                    break;
                case DateFilterType.ThisYear:
                    query = query.Where(f => f.CreateDate.Year == now.Year);
                    break;
            }

            // Tính trung bình số sao cho mỗi account
            var starAverages = await query
                .GroupBy(f => f.AccountId)
                .Select(g => new
                {
                    AccountId = g.Key,
                    AverageStar = g.Average(f => f.Star)
                })
                .OrderByDescending(a => a.AverageStar)
                .Take(5)
                .ToListAsync();

            // Lấy danh sách Account và gán AverageStar vào thuộc tính có sẵn
            var topAccounts = await _context.Accounts
                .Where(a => starAverages.Select(s => s.AccountId).Contains(a.AccountId))
                .ToListAsync();

            foreach (var account in topAccounts)
            {
                account.AverageStar = starAverages.FirstOrDefault(s => s.AccountId == account.AccountId)?.AverageStar;
            }

            return topAccounts
                .OrderByDescending(a => a.AverageStar) // Đảm bảo sắp xếp lại
                .ToList();
        }












    }
}
