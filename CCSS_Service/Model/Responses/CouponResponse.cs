using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CouponResponse
    {
        public string CouponId { get; set; }
        public string? CouponName { get; set; }
        public string? Condition { get; set; }
        public float? Percent { get; set; }
        public double? Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CouponType Type { get; set; }
    }
}
