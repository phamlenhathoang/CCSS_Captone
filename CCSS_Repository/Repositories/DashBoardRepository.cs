using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Repository.Repositories
{
    public interface IDashBoardRepository
    {
        Task<List<Payment>> GetRevenue(DateFilterType filterType, RevenueSource revenueSource);
        Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus? status, DateFilterType? filterType);
        Task<List<AccountDashboard>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<List<Feedback>> GetFeedbacksByContractDescriptionAsync();
        Task<List<CosplayerPopular>> Get5PopularCosplayers(DateFilterType filterType);
        Task<List<Account>> Get5FavoriteCosplayer(DateFilterType filterType);
        Task<List<Contract>> GetAllContractFilterServiceAndDate(string serviceId, DateTime startDate, DateTime endDate);
        Task<List<Contract>> GetAllContractFilterContractStatus(ContractStatus contractStatus);
        Task<List<Contract>> GetAllContractNotCompleted();
        Task<List<ContractCount>> GetTodayContractByHourAsync();
        Task<List<ContractCount>> GetContractByDayInMonthAsync();
        Task<List<ContractCount>> GetContractByMonthInYearAsync();
        Task<List<Contract>> GetAllContractByService(string serviceId);
        Task<List<ContractCount>> GetAllContractFilterServiceAndDateTime(string serviceId, DateFilterType dateFilterType);
        Task<List<Order>> GetAllOrder();
        Task<List<ContractCount>> GetAllOrderFilterDateTime(DateFilterType dateFilterType);
        Task<List<Payment>> GetAllPaymentForTicket();
        Task<List<ContractCount>> GetAllTicketAccountFilterDateTime(DateFilterType dateFilterType);
    }

    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly CCSSDbContext _context;
        public DashBoardRepository(CCSSDbContext cCSSDbContext)
        {
            _context = cCSSDbContext;
        }

        #region GetRevenue
        public async Task<List<Payment>> GetRevenue(DateFilterType filterType, RevenueSource revenueSource)
        {
            var now = DateTime.UtcNow;
            var query = _context.Payments.Include(sc => sc.Contract)
                .Where(p => p.Status == PaymentStatus.Complete) // PaymentStatus = 1
                .AsQueryable();

            // Lọc theo RevenueSource
            switch (revenueSource)
            {
                case RevenueSource.Order:
                    query = query.Where(p => p.Purpose == PaymentPurpose.Order || (p.Purpose == PaymentPurpose.Refund && p.OrderId != null));
                    break;
                case RevenueSource.festival:
                    query = query.Where(p => p.Purpose == PaymentPurpose.BuyTicket);
                    break;
                case RevenueSource.Service:
                    query = query.Where(p =>(p.Purpose == PaymentPurpose.contractSettlement || p.Purpose == PaymentPurpose.Refund)
                                            && p.OrderId == null);
                    break;
                case RevenueSource.Total:
                    query = query.Where(p => p.Purpose == PaymentPurpose.BuyTicket ||
                                             p.Purpose == PaymentPurpose.contractSettlement || 
                                             (p.Purpose == PaymentPurpose.Refund && p.OrderId == null) ||                   
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
        #endregion

        #region GetContractsByStatusAndDate
        public async Task<List<Contract>> GetContractsByStatusAndDate(ContractStatus? status, DateFilterType? filterType)
        {
            var now = DateTime.UtcNow;
            var query = _context.Contracts
                .Where(c => c.ContractStatus == status && c.Request != null) // Đảm bảo có Request
                .AsQueryable();
            if (status == null)
            {
                query = _context.Contracts.AsQueryable();
            }
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
                default:

                    break;
            }

            return await query.ToListAsync();
        }
        #endregion

        #region GetAllContractFilterServiceAndDate
        public async Task<List<Contract>> GetAllContractFilterServiceAndDate(string serviceId, DateTime startDate, DateTime endDate)
        {
            return await _context.Contracts.Include(r => r.Request)
                .Where(c => c.Request.ServiceId.Equals(serviceId) && c.CreateDate >= startDate && c.CreateDate <= endDate)
                .ToListAsync();
        }
        #endregion

        #region GetAllContractFilterContractStatus
        public async Task<List<Contract>> GetAllContractFilterContractStatus(ContractStatus contractStatus)
        {
            return await _context.Contracts.Where(c => c.ContractStatus.Equals(contractStatus)).ToListAsync();
        }
        #endregion

        #region GetAllContractNotCompleted
        public async Task<List<Contract>> GetAllContractNotCompleted()
        {
            return await _context.Contracts.Where(c => c.ContractStatus != ContractStatus.Completed).ToListAsync();
        }
        #endregion

        #region GetTop5AccountsWithMostPaymentsAsync
        public async Task<List<AccountDashboard>> GetTop5AccountsWithMostPaymentsAsync()
        {
            int currentYear = DateTime.UtcNow.Year;

            var result = await _context.Accounts
                .Where(a => a.Requests.Any(r =>
                    r.Contract != null &&
                    (r.Contract.ContractStatus == ContractStatus.Completed || r.Contract.ContractStatus == ContractStatus.Feedbacked) &&
                    r.Contract.Payments.Any(p =>
                        p.Status == PaymentStatus.Complete &&
                        (p.Purpose == PaymentPurpose.contractSettlement || p.Purpose == PaymentPurpose.Refund) &&
                        p.CreatAt.HasValue &&
                        p.CreatAt.Value.Year == currentYear
                    )
                ))
                .Select(a => new AccountDashboard
                {
                    AccountId = a.AccountId,
                    FullName = a.Name,
                    AccountImages = a.AccountImages.ToList(),

                    // Tổng số contract completed của account
                    TotalContracts = a.Requests
                        .Count(r => r.Contract != null && (r.Contract.ContractStatus == ContractStatus.Completed || r.Contract.ContractStatus == ContractStatus.Feedbacked)),

                    // Tổng số tiền đã thanh toán cho hợp đồng trong năm
                    TotalPaymentAmount = a.Requests
                        .Where(r => r.Contract != null && (r.Contract.ContractStatus == ContractStatus.Completed || r.Contract.ContractStatus == ContractStatus.Feedbacked))
                        .Sum(r => r.Contract.TotalPrice)
                })
                .OrderByDescending(x => x.TotalPaymentAmount)
                .Take(5)
                .ToListAsync();

            return result;
        }

        #endregion

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

        #region Get5PopularCosplayers
        public async Task<List<CosplayerPopular>> Get5PopularCosplayers(DateFilterType filterType)
        {
            var now = DateTime.UtcNow;

            // Lọc task đã hoàn thành theo filterType
            IQueryable<Task> tasksQuery = _context.Tasks.Where(t => t.Status == TaskStatus.Completed &&
                                                                    t.EventCharacterId == null &&
                                                                    t.ContractCharacterId != null);

            switch (filterType)
            {
                case DateFilterType.Today:
                    tasksQuery = tasksQuery.Where(t => t.StartDate.Value.Date == now.Date);
                    break;
                case DateFilterType.ThisWeek:
                    var dayOfWeek = (int)now.DayOfWeek;
                    var startOfWeek = now.Date.AddDays(dayOfWeek == 0 ? -6 : -dayOfWeek + 1);
                    var endOfWeek = startOfWeek.AddDays(6);
                    tasksQuery = tasksQuery.Where(t => t.StartDate.Value.Date >= startOfWeek &&
                                                       t.StartDate.Value.Date <= endOfWeek);
                    break;
                case DateFilterType.ThisMonth:
                    tasksQuery = tasksQuery.Where(t => t.StartDate.Value.Year == now.Year &&
                                                       t.StartDate.Value.Month == now.Month);
                    break;
                case DateFilterType.ThisYear:
                    tasksQuery = tasksQuery.Where(t => t.StartDate.Value.Year == now.Year);
                    break;
            }

            // Nhóm task theo AccountId và đếm số task
            var taskCounts = await tasksQuery
                .GroupBy(t => t.AccountId)
                .Select(g => new { AccountId = g.Key, TaskCount = g.Count() })
                .OrderByDescending(x => x.TaskCount)
                .Take(5)
                .ToListAsync();

            if (taskCounts.Count == 0)
                return new List<CosplayerPopular>();

            // Lấy thông tin Account của các cosplayer đã có task hoàn thành
            var accountIds = taskCounts.Select(tc => tc.AccountId).ToList();

            var cosplayers = await _context.Accounts
                .Where(a => accountIds.Contains(a.AccountId) && a.Role.RoleName == RoleName.Cosplayer)
                .ToListAsync();

            // Tạo danh sách response kết hợp Account và số task hoàn thành
            var result = cosplayers
                .Select(a => new CosplayerPopular
                {
                    Account = a,
                    CompletedTaskCount = taskCounts.First(tc => tc.AccountId == a.AccountId).TaskCount
                })
                .OrderByDescending(r => r.CompletedTaskCount)
                .ToList();

            return result;
        }


        #endregion

        #region Get5FavoriteCosplayer
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
        #endregion

        #region GetTodayContractByHourAsync
        public async Task<List<ContractCount>> GetTodayContractByHourAsync()
        {
            var now = DateTime.UtcNow; // Hoặc UtcNow tùy theo cách lưu
            var startOfDay = now.Date;
            var endOfDay = startOfDay.AddDays(1);

            var result = await _context.Contracts
                .Where(c => c.CreateDate.HasValue &&
                            c.CreateDate.Value >= startOfDay &&
                            c.CreateDate.Value < endOfDay)
                .GroupBy(c => c.CreateDate.Value.Hour)
                .Select(g => new ContractCount
                {
                    Hour = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Hour)
                .ToListAsync();

            // Đảm bảo đủ 24 giờ (0 - 23) kể cả khi không có data ở 1 số giờ
            var fullResult = Enumerable.Range(0, 24)
                .Select(h => new ContractCount
                {
                    Hour = h,
                    Count = result.FirstOrDefault(x => x.Hour == h)?.Count ?? 0
                })
                .ToList();

            return fullResult;
        }
        #endregion

        #region GetContractByDayInMonthAsync
        public async Task<List<ContractCount>> GetContractByDayInMonthAsync()
        {
            var now = DateTime.UtcNow;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var startOfNextMonth = startOfMonth.AddMonths(1);

            var result = await _context.Contracts
                .Where(c => c.CreateDate.HasValue &&
                            c.CreateDate.Value >= startOfMonth &&
                            c.CreateDate.Value < startOfNextMonth)
                .GroupBy(c => c.CreateDate.Value.Day)
                .Select(g => new ContractCount
                {
                    Day = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            var fullResult = Enumerable.Range(1, daysInMonth)
                .Select(day => new ContractCount
                {
                    Day = day,
                    Count = result.FirstOrDefault(x => x.Day == day)?.Count ?? 0
                })
                .ToList();

            return fullResult;
        }
        #endregion

        #region GetContractByMonthInYearAsync
        public async Task<List<ContractCount>> GetContractByMonthInYearAsync()
        {
            var now = DateTime.UtcNow;
            var startOfYear = new DateTime(now.Year, 1, 1);
            var startOfNextYear = startOfYear.AddYears(1);

            var result = await _context.Contracts
                .Where(c => c.CreateDate.HasValue &&
                            c.CreateDate.Value >= startOfYear &&
                            c.CreateDate.Value < startOfNextYear)
                .GroupBy(c => c.CreateDate.Value.Month)
                .Select(g => new ContractCount
                {
                    Month = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var fullResult = Enumerable.Range(1, 12)
                .Select(month => new ContractCount
                {
                    Month = month,
                    Count = result.FirstOrDefault(x => x.Month == month)?.Count ?? 0
                })
                .ToList();

            return fullResult;
        }
        #endregion

        #region GetAllContractByService
        public async Task<List<Contract>> GetAllContractByService(string serviceId)
        {
            return await _context.Contracts.Where(rc => rc.Request.ServiceId.Equals(serviceId) && rc.ContractStatus != ContractStatus.Cancel).ToListAsync();
        }
        #endregion

        #region GetAllContractFilterServiceAndDateTime
        public async Task<List<ContractCount>> GetAllContractFilterServiceAndDateTime(string serviceId, DateFilterType dateFilterType)
        {
            switch (dateFilterType)
            {
                case DateFilterType.Today:
                    var now = DateTime.UtcNow; // Hoặc UtcNow tùy theo cách lưu
                    var startOfDay = now.Date;
                    var endOfDay = startOfDay.AddDays(1);

                    var result = await _context.Contracts
                        .Where(c => c.CreateDate.HasValue &&
                                    c.CreateDate.Value >= startOfDay &&
                                    c.CreateDate.Value < endOfDay && c.Request.ServiceId.Equals(serviceId))
                        .GroupBy(c => c.CreateDate.Value.Hour)
                        .Select(g => new ContractCount
                        {
                            Hour = g.Key,
                            Count = g.Count()
                        })
                        .OrderBy(x => x.Hour)
                        .ToListAsync();

                    // Đảm bảo đủ 24 giờ (0 - 23) kể cả khi không có data ở 1 số giờ
                    var fullResult = Enumerable.Range(0, 24)
                        .Select(h => new ContractCount
                        {
                            Hour = h,
                            Count = result.FirstOrDefault(x => x.Hour == h)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult;
                case DateFilterType.ThisMonth:
                    var nowMonth = DateTime.UtcNow;
                    var startOfMonth = new DateTime(nowMonth.Year, nowMonth.Month, 1);
                    var startOfNextMonth = startOfMonth.AddMonths(1);

                    var result1 = await _context.Contracts
                        .Where(c => c.CreateDate.HasValue &&
                                    c.CreateDate.Value >= startOfMonth &&
                                    c.CreateDate.Value < startOfNextMonth && c.Request.ServiceId.Equals(serviceId))
                        .GroupBy(c => c.CreateDate.Value.Day)
                        .Select(g => new ContractCount
                        {
                            Day = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    int daysInMonth = DateTime.DaysInMonth(nowMonth.Year, nowMonth.Month);
                    var fullResult1 = Enumerable.Range(1, daysInMonth)
                        .Select(day => new ContractCount
                        {
                            Day = day,
                            Count = result1.FirstOrDefault(x => x.Day == day)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult1;
                case DateFilterType.ThisYear:
                    var nowYear = DateTime.UtcNow;
                    var startOfYear1 = new DateTime(nowYear.Year, 1, 1);
                    var startOfNextYear1 = startOfYear1.AddYears(1);

                    var result2 = await _context.Contracts
                        .Where(c => c.CreateDate.HasValue &&
                                    c.CreateDate.Value >= startOfYear1 &&
                                    c.CreateDate.Value < startOfNextYear1 && c.Request.ServiceId.Equals(serviceId))
                        .GroupBy(c => c.CreateDate.Value.Month)
                        .Select(g => new ContractCount
                        {
                            Month = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    var fullResult2 = Enumerable.Range(1, 12)
                        .Select(month => new ContractCount
                        {
                            Month = month,
                            Count = result2.FirstOrDefault(x => x.Month == month)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult2;
                default:
                    return null;
            }
        }
        #endregion

        #region GetAllOrder
        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders.Where(sc => sc.OrderStatus != OrderStatus.Cancel).ToListAsync();
        }
        #endregion

        #region GetAllOrderFilterDateTime
        public async Task<List<ContractCount>> GetAllOrderFilterDateTime(DateFilterType dateFilterType)
        {
            switch (dateFilterType)
            {
                case DateFilterType.Today:
                    var now = DateTime.UtcNow; // Hoặc UtcNow tùy theo cách lưu
                    var startOfDay = now.Date;
                    var endOfDay = startOfDay.AddDays(1);

                    var result = await _context.Orders
                        .Where(c => c.OrderDate.HasValue &&
                                    c.OrderDate.Value >= startOfDay &&
                                    c.OrderDate.Value < endOfDay)
                        .GroupBy(c => c.OrderDate.Value.Hour)
                        .Select(g => new ContractCount
                        {
                            Hour = g.Key,
                            Count = g.Count()
                        })
                        .OrderBy(x => x.Hour)
                        .ToListAsync();

                    // Đảm bảo đủ 24 giờ (0 - 23) kể cả khi không có data ở 1 số giờ
                    var fullResult = Enumerable.Range(0, 24)
                        .Select(h => new ContractCount
                        {
                            Hour = h,
                            Count = result.FirstOrDefault(x => x.Hour == h)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult;
                case DateFilterType.ThisMonth:
                    var nowMonth = DateTime.UtcNow;
                    var startOfMonth = new DateTime(nowMonth.Year, nowMonth.Month, 1);
                    var startOfNextMonth = startOfMonth.AddMonths(1);

                    var result1 = await _context.Orders
                        .Where(c => c.OrderDate.HasValue &&
                                    c.OrderDate.Value >= startOfMonth &&
                                    c.OrderDate.Value < startOfNextMonth)
                        .GroupBy(c => c.OrderDate.Value.Day)
                        .Select(g => new ContractCount
                        {
                            Day = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    int daysInMonth = DateTime.DaysInMonth(nowMonth.Year, nowMonth.Month);
                    var fullResult1 = Enumerable.Range(1, daysInMonth)
                        .Select(day => new ContractCount
                        {
                            Day = day,
                            Count = result1.FirstOrDefault(x => x.Day == day)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult1;
                case DateFilterType.ThisYear:
                    var nowYear = DateTime.UtcNow;
                    var startOfYear1 = new DateTime(nowYear.Year, 1, 1);
                    var startOfNextYear1 = startOfYear1.AddYears(1);

                    var result2 = await _context.Orders
                        .Where(c => c.OrderDate.HasValue &&
                                    c.OrderDate.Value >= startOfYear1 &&
                                    c.OrderDate.Value < startOfNextYear1)
                        .GroupBy(c => c.OrderDate.Value.Month)
                        .Select(g => new ContractCount
                        {
                            Month = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    var fullResult2 = Enumerable.Range(1, 12)
                        .Select(month => new ContractCount
                        {
                            Month = month,
                            Count = result2.FirstOrDefault(x => x.Month == month)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult2;
                default:
                    return null;
            }
        }
        #endregion

        #region GetAllPaymentForTicket
        public async Task<List<Payment>> GetAllPaymentForTicket()
        {
           return await _context.Payments.Where(sc => sc.TicketAccountId != null && sc.OrderId == null && sc.ContractId == null).ToListAsync();
        }
        #endregion

        #region GetAllTicketAccountFilterDateTime
        public async Task<List<ContractCount>> GetAllTicketAccountFilterDateTime(DateFilterType dateFilterType)
        {
            switch (dateFilterType)
            {
                case DateFilterType.Today:
                    var now = DateTime.UtcNow; // Hoặc UtcNow tùy theo cách lưu
                    var startOfDay = now.Date;
                    var endOfDay = startOfDay.AddDays(1);

                    var result = await _context.Payments
                        .Where(c => c.CreatAt.HasValue &&
                                    c.CreatAt.Value >= startOfDay &&
                                    c.CreatAt.Value < endOfDay && c.TicketAccountId !=null)
                        .GroupBy(c => c.CreatAt.Value.Hour)
                        .Select(g => new ContractCount
                        {
                            Hour = g.Key,
                            Count = g.Count()
                        })
                        .OrderBy(x => x.Hour)
                        .ToListAsync();

                    // Đảm bảo đủ 24 giờ (0 - 23) kể cả khi không có data ở 1 số giờ
                    var fullResult = Enumerable.Range(0, 24)
                        .Select(h => new ContractCount
                        {
                            Hour = h,
                            Count = result.FirstOrDefault(x => x.Hour == h)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult;
                case DateFilterType.ThisMonth:
                    var nowMonth = DateTime.UtcNow;
                    var startOfMonth = new DateTime(nowMonth.Year, nowMonth.Month, 1);
                    var startOfNextMonth = startOfMonth.AddMonths(1);

                    var result1 = await _context.Payments
                        .Where(c => c.CreatAt.HasValue &&
                                    c.CreatAt.Value >= startOfMonth &&
                                    c.CreatAt.Value < startOfNextMonth && c.TicketAccountId != null)
                        .GroupBy(c => c.CreatAt.Value.Day)
                        .Select(g => new ContractCount
                        {
                            Day = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    int daysInMonth = DateTime.DaysInMonth(nowMonth.Year, nowMonth.Month);
                    var fullResult1 = Enumerable.Range(1, daysInMonth)
                        .Select(day => new ContractCount
                        {
                            Day = day,
                            Count = result1.FirstOrDefault(x => x.Day == day)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult1;
                case DateFilterType.ThisYear:
                    var nowYear = DateTime.UtcNow;
                    var startOfYear1 = new DateTime(nowYear.Year, 1, 1);
                    var startOfNextYear1 = startOfYear1.AddYears(1);

                    var result2 = await _context.Payments
                        .Where(c => c.CreatAt.HasValue &&
                                    c.CreatAt.Value >= startOfYear1 &&
                                    c.CreatAt.Value < startOfNextYear1 && c.TicketAccountId != null)
                        .GroupBy(c => c.CreatAt.Value.Month)
                        .Select(g => new ContractCount
                        {
                            Month = g.Key,
                            Count = g.Count()
                        })
                        .ToListAsync();

                    var fullResult2 = Enumerable.Range(1, 12)
                        .Select(month => new ContractCount
                        {
                            Month = month,
                            Count = result2.FirstOrDefault(x => x.Month == month)?.Count ?? 0
                        })
                        .ToList();

                    return fullResult2;
                default:
                    return null;
            }
        }
        #endregion
    }
}

