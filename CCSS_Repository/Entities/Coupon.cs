using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Coupon")]
    public partial class Coupon
    {
        [Key]
        public string CouponId { get; set; } = Guid.NewGuid().ToString();
        public string Condition { get; set; }
        public float Percent {  get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public Order Order { get; set; }    
        public ICollection<Request> Requests { get; set; } = new List<Request>();
        public ICollection<AccountCoupon> AccountCoupons { get; set; } = new List<AccountCoupon>();
    }
}
