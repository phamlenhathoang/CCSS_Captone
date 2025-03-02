using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
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
        public ContractDescription Description { get; set; }       
        public double Price { get; set; }
        public double Amount { get; set; }
        public string? Location { get; set; }
        public bool Signature { get; set; }
        public string Deposit { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IFormFile UrlImage { get; set; }
        public List<CharacterSelection> contractCharacterRequests { get; set; }



    }

    public class CharacterSelection
    {
        public string CharacterId { get; set; }
        public int Quantity { get; set; }
    }
}
