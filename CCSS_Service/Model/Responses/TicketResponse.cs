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
        public string TicketId { get; set; } = Guid.NewGuid().ToString();

        public string? AccountId { get; set; }
        //public Account Account { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

        public string? EventId { get; set; }
        public EventResponse Event { get; set; }

        //public Payment Payment { get; set; }
    }
}

