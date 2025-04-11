using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("ContractRefund")]
    public class ContractRefund
    {
        [Key]
        public string ContractRefundId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Contract")]
        public string ContractId { get; set; }
        public Contract Contract { get; set; }

        public string? NumberBank { get; set; }
        public string? BankName { get; set; }
        public string? AccountBankName { get; set; }
        public DateTime? CraeteDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
