using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ApiProvinceResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ProvinceResponse> Data { get; set; }
    }
    public class ProvinceResponse
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
