using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("AccountCoupon")]
    public partial class AccountCoupon
    {
        [Key]
        public string AccountCouponId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("CouponId")]
        public string? CouponId { get; set; }    
        public Coupon Coupon { get; set; }

        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Payment Payment { get; set; }
        public Contract Contract { get; set; }
    }
}
