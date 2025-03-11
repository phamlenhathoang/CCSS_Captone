using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public string FeedbackId { get; set; } = Guid.NewGuid().ToString(); 
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreateBy { get; set; }

        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
