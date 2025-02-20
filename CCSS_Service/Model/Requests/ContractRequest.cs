using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class ContractRequest
    { 
        public string AccountId { get; set; } 
        public string PackageId { get; set; }
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public bool Signature { get; set; }
        public string Deposit { get; set; }
        public ContractStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }     
        //public List<ContractChracterRequest>?  contractChracterRequests { get; set; }
       
    }
}
