using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class OrderRequest
    {
       

        public string AccountId { get; set; }

        public ICollection<OrderProductRequest> OrderProducts { get; set; } = new List<OrderProductRequest>();

        
    }
}
