﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("CartProduct")]
    public partial class CartProduct
    {
        [Key]
        public string CartProductId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
        public Product Product { get; set; }


        [ForeignKey("CartId")]
        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }  
    }
}
