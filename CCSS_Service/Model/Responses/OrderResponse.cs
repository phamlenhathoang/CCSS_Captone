using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class OrderResponse
    {
        public string OrderId { get; set; }
        public string AccountId { get; set; }

        public ICollection<OrderProductResponse> OrderProducts { get; set; } = new List<OrderProductResponse>();

        public DateTime? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
