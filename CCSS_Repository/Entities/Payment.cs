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
        public string Type { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }
        public string TransactionId { get; set; }
        public string CreatAt { get; set; }

        [ForeignKey("OrderId")]
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        [ForeignKey("ContractId")]
        public string ContractId { get; set; }
        public Contract Contract { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
    }
}
