using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Cart")]

    public partial class Cart
    {
        [Key]
        public string CartId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }   
        public Account Account { get; set; }
        public double TotalPrice { get; set; }
        public Order Order { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();   
    }
}
