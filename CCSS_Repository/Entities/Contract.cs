using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Contract")]
    public partial class Contract
    {
        [Key]  
        public string ContractId { get; set; }

        [ForeignKey("RequestId")]
        public string? RequestId { get; set; }
        public Request? Request { get; set; }

        [ForeignKey("AccountCouponId")]
        public string? AccountCouponId { get; set; }
        public AccountCoupon AccountCoupon { get; set; }

        public string? Deposit {  get; set; }
        public double? TotalPrice { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public ICollection<ContractCharacter> ContractCharacters { get; set; } = new List<ContractCharacter>();
    }

    public enum ContractStatus
    {
        Cancel,
        Active,
        Expired,
        Completed,
    }
}
