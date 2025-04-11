using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class TicketResponse
    {
        public int TicketId { get; set; }

        public ticketType ticketType { get; set; }
        public string Description { get; set; }

        public int? Quantity { get; set; }
        public double? Price { get; set; }

        //public string? EventId { get; set; }
        public EventticketResponse Event { get; set; }

        //public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
    }

}

