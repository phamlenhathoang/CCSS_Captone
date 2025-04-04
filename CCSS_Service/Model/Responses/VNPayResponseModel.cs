using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class VNPayResponseModel
    {
        //public string OrderDescription { get; set; }
        //public string TransactionId { get; set; }
        //public string OrderId { get; set; }
        //public string PaymentMethod { get; set; }
        //public string PaymentId { get; set; }
        //public bool Success { get; set; }
        //public string Token { get; set; }
        //public string VnPayResponseCode { get; set; }

        public string OrderDescription { get; set; }
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
        public string AccountId { get; set; }
        public string? TicketId { get; set; }
        public string? TicketQuantity { get; set; }
        public string Purpose { get; set; }
        public string? ContractId { get; set; }
        public string? CartId { get; set; }
        public string? OrderPaymentId { get; set; }
        public double Amount { get; set; }

    }
}