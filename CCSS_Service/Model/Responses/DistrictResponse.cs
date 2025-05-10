using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ApiDistrictResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<DistrictResponse> Data { get; set; }
    }
    public class DistrictResponse
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}
