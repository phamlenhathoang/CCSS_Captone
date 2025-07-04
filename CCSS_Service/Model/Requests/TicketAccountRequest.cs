﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class TicketAccountRequest
    {

        public string? AccountId { get; set; }
        //public Account Account { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string? TicketCode { get; set; }


        //public Payment Payment { get; set; }

        public int TicketId { get; set; }
        //public Ticket Ticket { get; set; }
    }
    public class TicketCheckRequest
    {
        public string eventId { get; set; }
        public int quantity { get; set; }
        public string? TicketCode { get; set; }
    }
}
