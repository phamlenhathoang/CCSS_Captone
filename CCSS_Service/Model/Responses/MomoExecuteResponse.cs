using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class MomoExecuteResponse
    {
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string OrderInfo { get; set; }
        //public string CartId { get; set; }
        public PaymentPurpose Purpose { get; set; }

        public string AccountId { get; set; }
        public string? TicketId { get; set; }
        public int? TicketQuantity { get; set; }

    }
}
