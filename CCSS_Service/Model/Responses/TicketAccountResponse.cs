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
        public int quantitypurchased { get; set; }
        public double TotalPrice { get; set; }


        //public Payment Payment { get; set; }

        //[ForeignKey("TicketId")]
        public string? TicketId { get; set; }
        //public Ticket Ticket { get; set; }
    }
}
