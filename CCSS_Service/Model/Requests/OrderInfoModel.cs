using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class OrderInfoModel
    {
        public string FullName { get; set; }
        public string OrderId { get; set; }
        public string OrderInfo { get; set; }
        public double Amount { get; set; }
        public PaymentPurpose Purpose { get; set; }

        public string AccountId { get; set; }
        public string? AccountCouponId { get; set; }
        public string? TicketId { get; set; }
        public string? TicketQuantity { get; set; }
    }
}
