using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Response
{
    public class ContractResponse
    {
        public string ContractId { get; set; } = Guid.NewGuid().ToString();

      
        public string AccountId { get; set; }
        //public Account Account { get; set; }

     
        public string EventId { get; set; }
        //public Event Event { get; set; }

        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public double Price { get; set; }
        public bool Signature { get; set; }
        public string Name { get; set; }
        public int Deposit { get; set; }
        public double Amount { get; set; }

        //public Payment Payment { get; set; }
    }
}
