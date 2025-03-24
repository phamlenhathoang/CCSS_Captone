using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class OrderProductResponse
    {
        public string OrderProductId { get; set; } 
        public string ProductId { get; set; }
    
        public string OrderId { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
