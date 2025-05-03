using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class TicketRequest
    {
        public int TicketId { get; set; }


        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }

        public ticketType ticketType { get; set; }
        //[ForeignKey("EventId")]
        //public string? EventId { get; set; }
        //public Event Event { get; set; }

        //public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
    }
}
