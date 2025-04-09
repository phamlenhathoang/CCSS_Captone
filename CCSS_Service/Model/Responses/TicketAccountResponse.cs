using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class TicketAccountResponse
    {
        public string TicketAccountId { get; set; } = Guid.NewGuid().ToString();

        public string? AccountId { get; set; }
        //public Account Account { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string? TicketCode { get; set; }

        //public Payment Payment { get; set; }

        //[ForeignKey("TicketId")]
        public int? TicketId { get; set; }
        public TicketResponse Ticket { get; set; }
    }
}
