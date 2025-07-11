﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class OrderResponse
    {
        public string OrderId { get; set; }
        public string AccountId { get; set; }

        public ICollection<OrderProductResponse> OrderProducts { get; set; } = new List<OrderProductResponse>();

        public string Address { get; set; }
        public string Phone { get; set; }
        public ShipStatus? ShipStatus { get; set; }
        public string? Description { get; set; }
        public string? CancelReason { get; set; }

        public DateTime? CancelDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
