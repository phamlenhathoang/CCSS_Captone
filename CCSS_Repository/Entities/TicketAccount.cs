﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("TicketAccount")]
    public class TicketAccount
    {
        [Key]
        public string TicketAccountId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }
        public string TicketCode { get; set; }
        public Account Account { get; set; }
        public int Quantity { get; set; }
        public int participantQuantity { get; set; }
        public double TotalPrice { get; set; }
        

        public Payment Payment { get; set; }

        [ForeignKey("TicketId")]
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
