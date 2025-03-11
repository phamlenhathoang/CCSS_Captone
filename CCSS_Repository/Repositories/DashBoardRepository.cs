using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IDashBoardRepository
    {
        //Task<List<Payment>> GetALlRevenue(DateFilterType filterType);
        ////Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus status, DateFilterType filterType);
        //Task<List<Account>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<List<Feedback>> GetFeedbacksByContractDescriptionAsync();
        //Task<List<Account>> Get5PopularCosplayers(DateFilterType filterType);
    }

        public class DashBoardRepository : IDashBoardRepository
    {
        //private readonly CCSSDbContext _context;
        //public DashBoardRepository(CCSSDbContext cCSSDbContext)
        //{
        //    _context = cCSSDbContext;
        //}
        //public async Task<List<Payment>> GetALlRevenue(DateFilterType filterType)
        //{
        //    var now = DateTime.UtcNow;
        //    var query = _context.Payments
        //        .Where(p => p.Status == PaymentStatus.Complete && // PaymentStatus = 1
        //                    (p.Purpose == PaymentPurpose.BuyTicket ||
        //                     p.Purpose == PaymentPurpose.contractSettlement ||
        //                     p.Purpose == PaymentPurpose.Order)) // PaymentPurpose = 0, 2, 3
        //        .AsQueryable();

        //    switch (filterType)
        //    {
        //        case DateFilterType.Today:
        //            query = query.Where(p => p.CreatAt.HasValue &&
        //                                     p.CreatAt.Value.Date == now.Date);
        //            break;

        //        case DateFilterType.ThisWeek:
        //            var dayOfWeek = (int)now.DayOfWeek;
        //            var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -dayOfWeek + 1); // Luôn lùi về Thứ Hai tuần hiện tại
        //            var endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật cùng tuần
        //            query = query.Where(p => p.CreatAt.HasValue &&
        //                                     p.CreatAt.Value.Date >= startOfWeek &&
        //                                     p.CreatAt.Value.Date <= endOfWeek);
        //            break;

        //        case DateFilterType.ThisMonth:
        //            query = query.Where(p => p.CreatAt.HasValue &&
        //                                     p.CreatAt.Value.Year == now.Year &&
        //                                     p.CreatAt.Value.Month == now.Month);
        //            break;

        //        case DateFilterType.ThisYear:
        //            query = query.Where(p => p.CreatAt.HasValue &&
        //                                     p.CreatAt.Value.Year == now.Year);
        //            break;
        //    }

        //    return await query.ToListAsync();
        //}

        //public async Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus status, DateFilterType filterType)
        //{
        //    var now = DateTime.UtcNow;
        //    var query = _context.Contracts.Where(c => c.Status == status).AsQueryable();

        //    switch (filterType)
        //    {
        //        case DateFilterType.Today:
        //            query = query.Where(c => c.StartDate.Date == now.Date);
        //            break;

        //        case DateFilterType.ThisWeek:
        //            var dayOfWeek = (int)now.DayOfWeek;
        //            var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -(dayOfWeek - 1)); // Nếu Chủ nhật (0), lùi về Thứ 2 tuần trước
        //            query = query.Where(c => c.StartDate.Date >= startOfWeek && c.StartDate.Date <= now.Date);
        //            break;

        //        case DateFilterType.ThisMonth:
        //            query = query.Where(c => c.StartDate.Year == now.Year && c.StartDate.Month == now.Month);
        //            break;

        //        case DateFilterType.ThisYear:
        //            query = query.Where(c => c.StartDate.Year == now.Year);
        //            break;
        //    }

        //    return await query.ToListAsync();
        //}
        //public async Task<List<Account>> GetTop5AccountsWithMostPaymentsAsync()
        //{
        //    return await _context.Accounts
        //        .Where(a => a.Contracts.Any(c => c.Payments.Any(p => (int?)p.Status == 1 && (int?)p.Purpose == 2))) 
        //        .Include(a => a.Contracts)
        //        .ThenInclude(c => c.Payments)
        //        .OrderByDescending(a => a.Contracts.SelectMany(c => c.Payments).Count(p => (int?)p.Status == 1 && (int?)p.Purpose == 2)) 
        //        .Take(5)
        //        .ToListAsync();
        //}

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









    }
}
