using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("ContractImage")]
    public class ContractImage
    {
        [Key]
        public string ContractImageId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Contract")]
        public string ContractId { get; set; }
        public Contract Contract { get; set; }
        public string? Reason { get; set; }
        public string? UrlImage {  get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ContractImageStatus Status { get; set; }
    }

    public enum ContractImageStatus
    {
        Delivering,
        Received,
        Refund,
        Check,
        RefundMoney,
        Cancel
    }
}
