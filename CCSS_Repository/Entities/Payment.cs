using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Payment")]

    public partial class Payment
    {
        [Key]
        public string PaymentId { get; set; } = Guid.NewGuid().ToString();
        public string? Type { get; set; }
        public PaymentStatus? Status { get; set; }
        public PaymentPurpose Purpose { get; set; }
        public double? Amount { get; set; }
        public string? TransactionId { get; set; }
        public DateTime? CreatAt { get; set; }

        [ForeignKey("OrderId")]
        public string? OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("TicketAccountId")]
        public string? TicketAccountId { get; set; }
        public TicketAccount TicketAccount { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }

        [ForeignKey("AccountCouponID")]
        public string? AccountCouponID { get; set; }
        public AccountCoupon AccountCoupon { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Complete,
        Cancel
    }
    public enum PaymentPurpose
    {
        BuyTicket,
        ContractDeposit,
        contractSettlement,
        Order,
        Refund
    }
}
