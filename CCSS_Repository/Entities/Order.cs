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

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public DateTime? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Completed, 
        Cancel
    }
}
