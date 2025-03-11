using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Order")]
    public partial class Order
    {
        [Key]
        public string OrderId { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey("CouponId")]
        public string CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public string? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Completed, 
        Cancel
    }
}
