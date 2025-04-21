using Microsoft.Extensions.DependencyModel;
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

        public string? Deposit {  get; set; }
        public double? TotalPrice { get; set; }
        public double? Amount {  get; set; }
        public string? CreateBy { get; set; }
        public string? UrlPdf { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ContractName { get; set; }
        public string? Reason { get; set; }
        public ContractStatus? ContractStatus { get; set; }
        public DeliveryStatus? DeliveryStatus { get; set; }
        public ContractRefund ContractRefund { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        //public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public ICollection<ContractCharacter> ContractCharacters { get; set; } = new List<ContractCharacter>();
        public ICollection<ContractImage> ContractImages { get; set; } = new List<ContractImage>();
    }

    public enum ContractStatus
    {
        Cancel,
        Created,
        Deposited,
        FinalSettlement,
        Refund,
        Completed,
        Feedbacked,
        Expired,
    }

    public enum DeliveryStatus
    {
        Preparing,
        Delivering,
        Delevered,
        Completed,
        Cancel,
    }
}
