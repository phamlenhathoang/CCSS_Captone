using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();  
        public string? ProductName { get; set; } 
        public string? Description { get; set; }
        public int weight { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();   
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
