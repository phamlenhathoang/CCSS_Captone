using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ContractRefundResponse
    {
        public string ContractRefundId { get; set; } = Guid.NewGuid().ToString();
        public string ContractId { get; set; }
        public string? NumberBank { get; set; }
        public string? BankName { get; set; }
        public string? AccountBankName { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
    }
}
