﻿using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSS_Service
{
    public interface IDashBoardService
    {
        Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType, RevenueSource revenueSource);
        Task<DashBoardChartRevenueResponse> GetRevenueChartAsync(DateFilterType filterType, RevenueSource revenueSource);
        Task<List<Contract>> GetContractsByStatusAsync(ContractStatus? status, DateFilterType? filterType);
        Task<List<top5AccountDashboardResponse>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<double> GetAverageStarByContractDescriptionAsync();
        Task<List<CosplayerPopularResponse>> Get5PopularCosplayers(DateFilterType filterType);
        Task<List<AccountResponse>> Get5FavoriteCosplayer(DateFilterType filterType);
        Task<string> GetContractFilterSerivce(string serviceId);
        Task<string> GetAllContractFilterContractStatus(ContractStatus contractStatus);
        Task<string> GetAllContractFilterConplete();
        Task<List<ContractCount>> GetAllContractFilterByDateTime(DateFilterType dateFilterType);
        Task<List<Contract>> GetAllContractByServiceId(string serviceId);
        Task<List<ContractCount>> GetAllContractFilterServiceAndDateTime(string serviceId, DateFilterType dateFilterType);
        Task<List<ContractCount>> GetAllOrderFilterDateTime(DateFilterType dateFilterType);
        Task<List<Order>> GetAllOrder();
        Task<List<Payment>> GetAllPaymentForTicket();
        Task<List<ContractCount>> GetAllTicketAccountFilterDateTime(DateFilterType dateFilterType);

    }

    public class DashBoardService : IDashBoardService
    {
        private readonly IDashBoardRepository _dashBoardRepository;
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly IContractRespository _contractRespository;


        public DashBoardService(IDashBoardRepository dashBoardRepository, IMapper mapper, IServiceRepository serviceRepository, IContractRespository contractRespository)
        {
            _dashBoardRepository = dashBoardRepository;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _contractRespository = contractRespository;
        }

        #region GetRevenueAsync
        public async Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType, RevenueSource revenueSource)
        {
            var ticketAndPayment = await _dashBoardRepository.GetRevenue(filterType, revenueSource);
           
            var response = new DashBoardRevenueResponse
            {

                TotalRevenue = ticketAndPayment.Sum(p => p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 : 0) +

                                    ticketAndPayment.Sum(p => p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement && p.Contract != null) ? p.Contract.TotalPrice ?? 0 : 0)
                                    -
                                    ticketAndPayment.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0),


                PaymentResponse = ticketAndPayment.Select(p => new PaymentResponse
                {
                    PaymentId = p.PaymentId,
                    Amount = p.Amount,
                    Status = p.Status.ToString(),
                    Purpose = p.Purpose.ToString(),
                    CreatAt = p.CreatAt?.ToString("dd/MM/yyyy"),
                    ContractId = p.ContractId,
                    OrderId = p.OrderId,
                    TicketAccountId = p.TicketAccountId,
                }).ToList()
            };

            return response;
        }
        #endregion

        #region GetRevenueChartAsync
        public async Task<DashBoardChartRevenueResponse> GetRevenueChartAsync(DateFilterType filterType, RevenueSource revenueSource)
        {
            var ticketAndPayment = await _dashBoardRepository.GetRevenue(filterType, revenueSource);

            var response = new DashBoardChartRevenueResponse();

            // Tổng doanh thu
            response.TotalRevenue = ticketAndPayment.Sum(p => p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 : 0) +
                                    ticketAndPayment.Sum(p => p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement && p.Contract != null) ? p.Contract.TotalPrice ?? 0 : 0) - ticketAndPayment.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0);

            if (filterType == DateFilterType.ThisWeek || filterType == DateFilterType.ThisMonth)
            {
                response.DailyRevenue = ticketAndPayment
                    .Where(p => p.CreatAt.HasValue)
                    .GroupBy(p => p.CreatAt.Value.Date)
                    .Select(g => new DailyRevenueResponse
                    {
                        Date = g.Key,
                        TotalRevenue = g.Sum(p =>
                            p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 :
                            p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement) && p.Contract != null
                                ? p.Contract.TotalPrice ?? 0
                                : 0)
                            - g.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0)
                    })
                    .OrderBy(r => r.Date).ToList();
            }
            else if (filterType == DateFilterType.ThisYear)
            {
                response.MonthlyRevenue = ticketAndPayment
                    .Where(p => p.CreatAt.HasValue)
                    .GroupBy(p => new { p.CreatAt.Value.Year, p.CreatAt.Value.Month })
                    .Select(g => new MonthlyRevenueResponse
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        TotalRevenue = g.Sum(p =>
                            p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 :
                            p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement) && p.Contract != null
                                ? p.Contract.TotalPrice ?? 0
                                : 0)
                            - g.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0)
                    })
                    .OrderBy(r => r.Year).ThenBy(r => r.Month).ToList();
            }
            else if (filterType == DateFilterType.Today)
            {
                response.HourlyRevenue = ticketAndPayment
                    .Where(p => p.CreatAt.HasValue && p.CreatAt.Value.Date == DateTime.UtcNow.AddHours(7).Date)
                    .GroupBy(p => p.CreatAt.Value.Hour)
                    .Select(g => new HourlyRevenueResponse
                    {
                        Hour = g.Key.ToString(),
                        TotalRevenue = g.Sum(p =>
                            p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 :
                            p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement) && p.Contract != null
                                ? p.Contract.TotalPrice ?? 0
                                : 0)
                            - g.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0)
                    })
                    .OrderBy(r => r.Hour).ToList();
            }
            else
            {
                response.TotalRevenue = ticketAndPayment.Sum(p =>
                    p.ContractId == null && p.Purpose != PaymentPurpose.Refund ? p.Amount ?? 0 :
                    p.ContractId != null && (p.Purpose == PaymentPurpose.Refund || p.Purpose == PaymentPurpose.contractSettlement) && p.Contract != null
                        ? p.Contract.TotalPrice ?? 0
                        : 0)
                    - ticketAndPayment.Sum(p => p.OrderId != null && p.Purpose == PaymentPurpose.Refund ? p.Amount ?? 0 : 0);
            }

            return response;
        }

        #endregion


        public async Task<List<top5AccountDashboardResponse>> GetTop5AccountsWithMostPaymentsAsync()
        {
            //var accounts = await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync();
            return _mapper.Map<List<top5AccountDashboardResponse>>(await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync());
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



        public async Task<List<CosplayerPopularResponse>> Get5PopularCosplayers(DateFilterType filterType)
        {
            return _mapper.Map<List<CosplayerPopularResponse>>(await _dashBoardRepository.Get5PopularCosplayers(filterType));
        }
        public async Task<List<AccountResponse>> Get5FavoriteCosplayer(DateFilterType filterType)
        {
            return _mapper.Map<List<AccountResponse>>(await _dashBoardRepository.Get5FavoriteCosplayer(filterType));
        }
        public async Task<List<Contract>> GetContractsByStatusAsync(ContractStatus? status, DateFilterType? filterType)
        {
            return await _dashBoardRepository.GetContractsByStatusAndDate(status, filterType);
        }

        #region GetAllContractFilterContractStatus
        public async Task<string> GetAllContractFilterContractStatus(ContractStatus contractStatus)
        {
            var contracts = await _dashBoardRepository.GetAllContractFilterContractStatus(contractStatus);
            if (contracts == null)
            {
                return "Contract not found";
            }
            int count = contracts.Count();
            return $"Number of Contract {contractStatus} : {count} ";
        }
        #endregion

        #region GetContractFilterSerivce
        public async Task<string> GetContractFilterSerivce(string serviceId)
        {
            // Lấy ngày đầu tiên của tháng hiện tại
            var firstDayOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Lấy ngày đầu tiên của tháng trước
            var firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);

            // Lấy ngày cuối cùng của tháng hiện tại
            var lastDayOfCurrentMonth = firstDayOfCurrentMonth.AddMonths(1).AddDays(-1);

            // Lấy ngày cuối cùng của tháng trước
            var lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);

            // Lấy danh sách hợp đồng cho tháng hiện tại
            var currentMonthContracts = await _dashBoardRepository.GetAllContractFilterServiceAndDate(
                serviceId, firstDayOfCurrentMonth, lastDayOfCurrentMonth);

            // Lấy danh sách hợp đồng cho tháng trước
            var previousMonthContracts = await _dashBoardRepository.GetAllContractFilterServiceAndDate(
                serviceId, firstDayOfPreviousMonth, lastDayOfPreviousMonth);

            int currentCount = currentMonthContracts?.Count() ?? 0;
            int previousCount = previousMonthContracts?.Count() ?? 0;

            int difference = currentCount - previousCount;
            string trend = difference > 0 ? "tăng" : (difference < 0 ? "giảm" : "không đổi");

            double percentChange = 0;
            if (previousCount > 0)
            {
                percentChange = Math.Abs((double)difference / previousCount * 100);
            }

            return $"Số hợp đồng với dịch vụ '{serviceId}': {currentCount} " +
                   $"(tháng trước: {previousCount}, {trend} {Math.Abs(difference)} hợp đồng, " +
                   $"{percentChange:F2}%)";
        }
        #endregion

        #region GetAllContractFilterConplete
        public async Task<string> GetAllContractFilterConplete()
        {

            var contract = await _contractRespository.GetContracts();
            int countAllContract = contract.Count();

            var contractCompleted = await _dashBoardRepository.GetAllContractFilterContractStatus(ContractStatus.Completed);
            int countContractComplete = contractCompleted?.Count ?? 0;

            var contractNotCompleted = await _dashBoardRepository.GetAllContractNotCompleted();
            int countContractNotComplete = contractNotCompleted?.Count ?? 0;


            double percentCompleted = (double)countContractComplete / countAllContract * 100;

            return $"Number of Pending Contract: {countContractNotComplete}\n"
                + $"Number of Completed Contract: {countContractComplete}\n"
                + $"Percent Completed: {percentCompleted:F2}%\n";
        }
        #endregion

        #region GetAllContractFilterByDateTime
        public async Task<List<ContractCount>> GetAllContractFilterByDateTime(DateFilterType dateFilterType)
        {
            switch (dateFilterType)
            {
                case DateFilterType.Today:
                    return await _dashBoardRepository.GetTodayContractByHourAsync();
                case DateFilterType.ThisWeek:
                    return null;
                case DateFilterType.ThisMonth:
                    return await _dashBoardRepository.GetContractByDayInMonthAsync();
                case DateFilterType.ThisYear:
                    return await _dashBoardRepository.GetContractByMonthInYearAsync();
                default:
                    return null;
            }
        }
        #endregion

        #region GetAllContractByServiceId
        public async Task<List<Contract>> GetAllContractByServiceId(string serviceId)
        {
            return await _dashBoardRepository.GetAllContractByService(serviceId);
        }
        #endregion

        public async Task<List<ContractCount>> GetAllContractFilterServiceAndDateTime(string serviceId, DateFilterType dateFilterType)
        {
            return await _dashBoardRepository.GetAllContractFilterServiceAndDateTime(serviceId, dateFilterType);
        }

        public async Task<List<ContractCount>> GetAllOrderFilterDateTime(DateFilterType dateFilterType)
        {
            return await _dashBoardRepository.GetAllOrderFilterDateTime(dateFilterType);
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _dashBoardRepository.GetAllOrder();
        }

        public async Task<List<Payment>> GetAllPaymentForTicket()
        {
           return await _dashBoardRepository.GetAllPaymentForTicket();
        }

        public async Task<List<ContractCount>> GetAllTicketAccountFilterDateTime(DateFilterType dateFilterType)
        {
            return await _dashBoardRepository.GetAllTicketAccountFilterDateTime(dateFilterType);
        }
    }
}
