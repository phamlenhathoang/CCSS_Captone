using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CouponRequest
    {
        public string? CouponName { get; set; }
        public string? Condition { get; set; }
        public float Percent { get; set; }
        public double Amount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
      
    }
}
