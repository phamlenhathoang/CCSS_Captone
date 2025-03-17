using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class VNPayInformationModel
    {
        public string OrderType { get; set; }
        public PaymentPurpose Purpose { get; set; }

        public double Amount { get; set; }
        public string OrderDescription { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public string? TicketId { get; set; }
        public string? TicketQuantity { get; set; }
        public string? ContractId { get; set; }
        public string? CartId { get; set; }

    }
}