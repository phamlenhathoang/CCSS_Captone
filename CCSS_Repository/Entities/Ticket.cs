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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public int? Quantity { get; set; }
        public double? Price { get; set; }

        [ForeignKey("EventId")]
        public string? EventId { get; set; }
        public Event Event { get; set; }
        public string Description { get; set; }

        public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
        public ticketType ticketType { get; set; }

    }
    public enum ticketType
    {
        Nomal,
        Premium
    }
}
