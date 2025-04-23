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
        public string ContractId { get; set; }  
        public string RequestId { get; set; }  
        public string? PackageName { get; set; }
        public double? AccountCoupon { get; set; }
        public string? ContractName { get; set; }
        //public ContractDescription Description { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public string? Deposit { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? CreateBy { get; set; }
        public string? UrlPdf { get; set; }
        public string? CreateDate { get; set; }
        public List<ListContractCharcterResponse>? ContractCharacters { get; set; }
    }

    public class ListContractCharcterResponse
    {
        public string? CosplayerName { get; set; }
        public string? CharacterName { get; set; }
        public int? Quantity {  get; set; }
    }
}
