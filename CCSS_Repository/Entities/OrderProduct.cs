using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("OrderProduct")]
    public partial class OrderProduct
    {
        [Key]
        public string OrderProductId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("ProductId")]
        public string ProductId { get; set; }   
        public Product Product { get; set; }

        [ForeignKey("OrderId")]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
