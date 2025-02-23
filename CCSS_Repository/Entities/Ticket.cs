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

       
        public int? Quantity { get; set; }
        public double? Price { get; set; }

        [ForeignKey("EventId")]
        public string? EventId { get; set; }
        public Event Event { get; set; }

        public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();

    }
}
