using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    
    public class ApiWardResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<WardResponse> Data { get; set; }
    }
    public class WardResponse
    {
        public int WardCode { get; set; }
        public string WardName { get; set; }
    }
}
