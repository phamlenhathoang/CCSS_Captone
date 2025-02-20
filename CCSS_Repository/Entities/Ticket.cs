using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Ticket")]

    public partial class Ticket
    {
        [Key]
        public string TicketId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }    
        public virtual Account Account { get; set; }    
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("PaymentId")]
        public string PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
