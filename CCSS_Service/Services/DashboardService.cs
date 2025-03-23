using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCSS_Service
{
    public interface IDashBoardService
    {
        Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType, RevenueSource revenueSource);
        Task<DashBoardChartRevenueResponse> GetRevenueChartAsync(DateFilterType filterType, RevenueSource revenueSource);
        Task<List<Contract>> GetContractsByStatusAsync(ContractStatus status, DateFilterType filterType);
        Task<List<AccountDashBoardResponse>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<double> GetAverageStarByContractDescriptionAsync();
        Task<List<AccountResponse>> Get5PopularCosplayers(DateFilterType filterType);
        Task<List<AccountResponse>> Get5FavoriteCosplayer(DateFilterType filterType);

    }

    public class DashBoardService : IDashBoardService
    {
        private readonly IDashBoardRepository _dashBoardRepository;
        private readonly IMapper _mapper;


        public DashBoardService(IDashBoardRepository dashBoardRepository, IMapper mapper)
        {
            _dashBoardRepository = dashBoardRepository;
            _mapper = mapper;
        }

        public async Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType, RevenueSource revenueSource)
        {
            var ticketAndPayment = await _dashBoardRepository.GetRevenue(filterType, revenueSource);

            var response = new DashBoardRevenueResponse
            {
                TotalRevenue = ticketAndPayment.Sum(p => p.Amount ?? 0),
                PaymentResponse = ticketAndPayment.Select(p => new PaymentResponse
                {
                    PaymentId = p.PaymentId,
                    Amount = p.Amount,
                    Status = p.Status,
                    Purpose = p.Purpose,
                    CreatAt = p.CreatAt
                }).ToList()
            };

            return response;
        }
        public async Task<DashBoardChartRevenueResponse> GetRevenueChartAsync(DateFilterType filterType, RevenueSource revenueSource)
        {
            var ticketAndPayment = await _dashBoardRepository.GetRevenue(filterType, revenueSource);

            var response = new DashBoardChartRevenueResponse();
            response.TotalRevenue = ticketAndPayment.Sum(p => (p.Amount ?? 0));
                
            if (filterType == DateFilterType.ThisWeek || filterType == DateFilterType.ThisMonth)
            {
                response.DailyRevenue = ticketAndPayment
                    .Where(p => p.CreatAt.HasValue)
                    .GroupBy(p => p.CreatAt.Value.Date) // Nhóm theo ngày
                    .Select(g => new DailyRevenueResponse
                    {
                        Date = g.Key,
                        TotalRevenue = g.Sum(p => p.Amount ?? 0)
                    }).OrderBy(r => r.Date).ToList();
            }
            else if (filterType == DateFilterType.ThisYear)
            {
                response.MonthlyRevenue = ticketAndPayment
                    .Where(p => p.CreatAt.HasValue)
                    .GroupBy(p => new { p.CreatAt.Value.Year, p.CreatAt.Value.Month }) // Nhóm theo tháng
                    .Select(g => new MonthlyRevenueResponse
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        TotalRevenue = g.Sum(p => p.Amount ?? 0)
                    }).OrderBy(r => r.Year).ThenBy(r => r.Month).ToList();
            }
            else
            {
                response.TotalRevenue = ticketAndPayment.Sum(p => p.Amount ?? 0);
            }

            return response;
        }


        public async Task<List<AccountDashBoardResponse>> GetTop5AccountsWithMostPaymentsAsync()
        {
            //var accounts = await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync();
            return _mapper.Map<List<AccountDashBoardResponse>>(await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync());
        }
        //public async Task<List<AccountResponse>> Get5PopularCosplayers(DateFilterType filterType)
        //{
        //    //var accounts = await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync();
        //    return _mapper.Map<List<AccountResponse>>(await _dashBoardRepository.Get5PopularCosplayers(filterType));
        //}
        //public async Task<double> GetAverageStarByContractDescriptionAsync()
        //{
        //    var feedbacks = await _dashBoardRepository.GetFeedbacksByContractDescriptionAsync();

        //    return feedbacks.Any()
        //        ? feedbacks.Average(f => f.Star ?? 0) // Nếu `Star` là null thì tính là 0
        //        : 0;
        //}
        public async Task<List<AccountResponse>> Get5PopularCosplayers(DateFilterType filterType)
        {
            return _mapper.Map<List<AccountResponse>>(await _dashBoardRepository.Get5PopularCosplayers(filterType));
        }
        public async Task<List<AccountResponse>> Get5FavoriteCosplayer(DateFilterType filterType)
        {
            return _mapper.Map<List<AccountResponse>>(await _dashBoardRepository.Get5FavoriteCosplayer(filterType));
        }
        public async Task<List<Contract>> GetContractsByStatusAsync(ContractStatus status, DateFilterType filterType)
        {
            return await _dashBoardRepository.GetContractsByStatusAndDate(status, filterType);
        }
    }
}
