using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Request
{
    public class ContractRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Signature { get; set; }
        public int Deposit { get; set; }
        public double Amount { get; set; }

        //public DateTime CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }
        //public Payment Payment { get; set; }
    }
}
