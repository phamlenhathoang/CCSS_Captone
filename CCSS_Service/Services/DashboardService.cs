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
        //Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType);
        ////Task<List<Contract>> GetContractsByStatusAsync(ContractStatus status, DateFilterType filterType);
        //Task<List<AccountResponse>> GetTop5AccountsWithMostPaymentsAsync();
        //Task<double> GetAverageStarByContractDescriptionAsync();
        //Task<List<AccountResponse>> Get5PopularCosplayers(DateFilterType filterType);

    }

    public class DashBoardService : IDashBoardService
    {
        //private readonly IDashBoardRepository _dashBoardRepository;
        //private readonly IMapper _mapper;


        //public DashBoardService(IDashBoardRepository dashBoardRepository, IMapper mapper)
        //{
        //    _dashBoardRepository = dashBoardRepository;
        //    _mapper = mapper;
        //}

        //public async Task<DashBoardRevenueResponse> GetRevenueAsync(DateFilterType filterType)
        //{
        //    var payments = await _dashBoardRepository.GetALlRevenue(filterType);

        //    var response = new DashBoardRevenueResponse
        //    {
        //        TotalRevenue = payments.Sum(p => p.Amount ?? 0),
        //        PaymentResponse = payments.Select(p => new PaymentResponse
        //        {
        //            PaymentId = p.PaymentId,
        //            Amount = p.Amount,
        //            Status = p.Status,
        //            Purpose = p.Purpose,
        //            CreatAt = p.CreatAt
        //        }).ToList()
        //    };

        //    return response;
        //}

        //public async Task<List<AccountResponse>> GetTop5AccountsWithMostPaymentsAsync()
        //{
        //    //var accounts = await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync();
        //    return _mapper.Map<List<AccountResponse>>(await _dashBoardRepository.GetTop5AccountsWithMostPaymentsAsync());
        //}
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
        //public async Task<List<Contract>> GetContractsByStatusAsync(ContractStatus status, DateFilterType filterType)
        //{
        //    return await _dashBoardRepository.GetContractsByStatusAndDate(status, filterType);
        //}
    }
}
