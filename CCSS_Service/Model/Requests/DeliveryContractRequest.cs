using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class DeliveryContractRequest
    {
        public string ContractId { get; set; }
        public string Status {  get; set; }
        public List<IFormFile>? Images { get; set; }
        public string? Reason { get; set; }
    }
}
