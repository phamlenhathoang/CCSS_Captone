using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CartResponse
    {
        public string CartId { get; set; }
        public string AccountId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public List<CartProductResponse> ListCartProduct { get; set; }
    }

    public class CartProductResponse
    {
        public string CartProductId { get; set; } 
        public string ProductId { get; set; }
        public double? Price { get; set; }
        public double? CartProductPrice { get; set; }
        public string UrlImage { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
