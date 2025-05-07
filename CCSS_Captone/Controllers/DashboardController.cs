using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Service;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCSS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }

        /// <summary>
        /// Lấy tổng doanh thu theo thời gian (hôm nay, tuần này, tháng này, năm nay).
        /// </summary>
        [HttpGet("revenue")]
        [SwaggerOperation(Description = "filterType<br>" +
                                "0 (Today)<br>" +
                                "1 (This week)<br>" +
                                "2 (This month)<br>" +
                                "3 (This Year)<br><br>" +

                                "revenueSource<br>" +
                                "0 (Order)<br>" +
                                "1 (festival)<br>" +
                                "2 (Service)<br>" +
                                "3 (Total))<br>"  

                                )]
        public async Task<ActionResult<DashBoardRevenueResponse>> GetRevenue([FromQuery] DateFilterType filterType, RevenueSource revenueSource)
        {
            var result = await _dashBoardService.GetRevenueAsync(filterType, revenueSource);
            return Ok(result);
        }

        [HttpGet("revenueChart")]
        [SwaggerOperation(Description = "filterType<br>" +
                                "1 (This week)<br>" +
                                "2 (This month)<br>" +
                                "3 (This Year)<br><br>" +

                                "revenueSource<br>" +
                                "0 (Order)<br>" +
                                "1 (festival)<br>" +
                                "2 (Service)<br>" +
                                "3 (Total))<br>")]
        public async Task<ActionResult<DashBoardChartRevenueResponse>> GetRevenueChart([FromQuery] DateFilterType filterType, RevenueSource revenueSource)
        {
            var result = await _dashBoardService.GetRevenueChartAsync(filterType, revenueSource);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách hợp đồng theo trạng thái và thời gian.
        /// </summary>
        [HttpGet("contracts")]
        [SwaggerOperation(Description = "ContractStatus<br>" +
                                "0 (Cancel)<br>" +
                                "1 (Active)<br>" +
                                "2 (Progressing)<br>" +
                                "3 (Completed))<br>" +
                                "4 (Expired))<br><br>" +
              
                                "filterType<br>" +
                                "0 (Today)<br>" +
                                "1 (This week)<br>" +
                                "2 (This month)<br>" +
                                "3 (This Year)")]
        public async Task<ActionResult<List<Contract>>> GetContractsByStatus([FromQuery] ContractStatus? status, [FromQuery] DateFilterType? filterType)
        {
            var result = await _dashBoardService.GetContractsByStatusAsync(status, filterType);
            return Ok(result);
        }

        [HttpGet("top-accounts")]
        public async Task<ActionResult<List<AccountResponse>>> GetTopAccounts()
        {
            var result = await _dashBoardService.GetTop5AccountsWithMostPaymentsAsync();
            return Ok(result);
        }
        [HttpGet("top5-Popular-cosplayer")]
        [SwaggerOperation(Description =  "filterType<br>" +
                                         "0 (Today)<br>" +
                                         "1 (This week)<br>" +
                                         "2 (This month)<br>" +
                                         "3 (This Year)")]
        public async Task<ActionResult<List<AccountResponse>>> Get5PopularCosplayers([FromQuery] DateFilterType filterType)
        {
            var result = await _dashBoardService.Get5PopularCosplayers(filterType);
            return Ok(result);
        }

        [HttpGet("top5-Favorite-cosplayer")]
        [SwaggerOperation(Description = "filterType<br>" +
                                         "0 (Today)<br>" +
                                         "1 (This week)<br>" +
                                         "2 (This month)<br>" +
                                         "3 (This Year)")]
        public async Task<ActionResult<List<AccountResponse>>> Get5FavoriteCosplayer([FromQuery] DateFilterType filterType)
        {
            var result = await _dashBoardService.Get5FavoriteCosplayer(filterType);
            return Ok(result);
        }


        [HttpGet("GetAllContractFilterService")]
        public async Task<IActionResult> GetAllContractFilterService(string serviceId)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashBoardService.GetContractFilterSerivce(serviceId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        //[HttpGet("total-average-star")]
        //public async Task<IActionResult> GetAverageStarByContractDescription()
        //{
        //    double averageStar = await _dashBoardService.GetAverageStarByContractDescriptionAsync();

        //    return Ok(new { AverageStar = averageStar });
        //}
    }
}
