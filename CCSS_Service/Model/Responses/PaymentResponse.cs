using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class PaymentResponse
    {
        public string PaymentId { get; set; } 
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Purpose { get; set; }
        public double? Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? CreatAt { get; set; }

        
        //public string? OrderId { get; set; }
        //public Order Order { get; set; }

        //public string? TicketAccountId { get; set; }
        //public TicketAccount TicketAccount { get; set; }

        //public string? ContractId { get; set; }
        //public Contract Contract { get; set; }
    }
}
