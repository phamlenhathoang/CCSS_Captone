using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class RequestInContractResponse
    {
        public string ContractId { get; set; }
        public RequestResponse RequestResponse { get; set; }
    }
}
