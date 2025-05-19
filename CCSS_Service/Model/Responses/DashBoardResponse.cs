using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class DashBoardRevenueResponse
    {
        public double TotalRevenue { get; set; }
        public ICollection<PaymentResponse> PaymentResponse { get; set; } = new List<PaymentResponse>();

    }
    public class top5AccountDashboardResponse
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public int TotalContracts { get; set; }
        public double? TotalPaymentAmount { get; set; }
        public ICollection<AccountImageResponse> AccountImages { get; set; } = new List<AccountImageResponse>();
    }
    public class CosplayerPopularResponse
    {
        public AccountDashBoardResponse Account { get; set; }
        public int CompletedTaskCount { get; set; }
    }
    public class DashBoardChartRevenueResponse
    {
        public double TotalRevenue { get; set; }
        public List<DailyRevenueResponse> DailyRevenue { get; set; } = new();
        public List<MonthlyRevenueResponse> MonthlyRevenue { get; set; } = new();
    }

    public class DailyRevenueResponse
    {
        public DateTime Date { get; set; }
        public double TotalRevenue { get; set; }
    }

    public class MonthlyRevenueResponse
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public double TotalRevenue { get; set; }
    }

}
