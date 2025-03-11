using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ContractResponse
    {   
        public string PackageId { get; set; }
        public string ContractName { get; set; }
        //public ContractDescription Description { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public bool Signature { get; set; }
        public string Deposit { get; set; }
        public ContractStatus Status { get; set; }
        public DateTime EndDate { get; set; }
    }
}
