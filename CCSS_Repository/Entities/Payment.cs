﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        public string PaymentId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("ContractId")]
        public string ContractId { get; set; }
        public Contract Contract { get; set; }

        public string Type { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string TransactionId { get; set; }   
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Cancel
    }
}
