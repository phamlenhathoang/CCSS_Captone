using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CancelDeleveryResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<CancelDeleveryDataResponse> Data { get; set; }
    }
    public class CancelDeleveryDataResponse
    {
        public string order_code { get; set; }
        public string result { get; set; }
        public string message { get; set; }

    }
}
