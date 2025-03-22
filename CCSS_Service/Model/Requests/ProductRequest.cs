
using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }  
        public bool? IsActive { get; set; }    
    }

 
}
