using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("ProductImage")]
    public partial class ProductImage
    {
        [Key]
        public string ProductImageId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string UrlImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
