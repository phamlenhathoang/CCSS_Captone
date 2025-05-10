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
        public ICollection<Payment> Payment { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public DateTime? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }   
        public string? ShipStatus { get; set; }   
        public string? ShipCode { get; set; }   
        public string? to_ward_code { get; set; }   
        public string? to_district_id { get; set; }   
        public DateTime? CancelDate { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Completed, 
        Cancel
    }
}
