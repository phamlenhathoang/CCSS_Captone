using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CartProductRequest
    {   
        public string ProductId { get; set; } 
        //public string CartId { get; set; }     
        //public double? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
