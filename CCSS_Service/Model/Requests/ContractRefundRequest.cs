using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class ContractRefundRequest
    {
        public string ContractId { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? Images { get; set; }
    }

    public class UpdateContractRefundRequest
    {
        public string ContractId { get; set; }
        public string? NumberBank { get; set; }
        public string? BankName { get; set; }
        public string? AccountBankName { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
    }
}
