using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Service;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCSS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        //private readonly IDashBoardService _dashBoardService;

        //public DashBoardController(IDashBoardService dashBoardService)
        //{
        //    _dashBoardService = dashBoardService;
        //}

        ///// <summary>
        ///// Lấy tổng doanh thu theo thời gian (hôm nay, tuần này, tháng này, năm nay).
        ///// </summary>
        //[HttpGet("revenue")]
        //public async Task<ActionResult<DashBoardRevenueResponse>> GetRevenue([FromQuery] DateFilterType filterType)
        //{
        //    var result = await _dashBoardService.GetRevenueAsync(filterType);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// Lấy danh sách hợp đồng theo trạng thái và thời gian.
        ///// </summary>
        ////[HttpGet("contracts")]
        ////public async Task<ActionResult<List<Contract>>> GetContractsByStatus([FromQuery] ContractStatus status, [FromQuery] DateFilterType filterType)
        ////{
        ////    var result = await _dashBoardService.GetContractsByStatusAsync(status, filterType);
        ////    return Ok(result);
        ////}

        //[HttpGet("top-accounts")]
        //public async Task<ActionResult<List<AccountResponse>>> GetTopAccounts()
        //{
        //    var result = await _dashBoardService.GetTop5AccountsWithMostPaymentsAsync();
        //    return Ok(result);
        //}
        //[HttpGet("top-cosplayer")]
        //public async Task<ActionResult<List<AccountResponse>>> GetTopCosplayer([FromQuery] DateFilterType filterType)
        //{
        //    var result = await _dashBoardService.Get5PopularCosplayers(filterType);
        //    return Ok(result);
        //}

        //[HttpGet("total-average-star")]
        //public async Task<IActionResult> GetAverageStarByContractDescription()
        //{
        //    double averageStar = await _dashBoardService.GetAverageStarByContractDescriptionAsync();

        //    return Ok(new { AverageStar = averageStar });
        //}
    }
}
