using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("AccountCategory")]
    public partial class AccountCategory
    {
        [Key]
        public string AccountCategoryId { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
