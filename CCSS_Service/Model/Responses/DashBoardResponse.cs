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
}
