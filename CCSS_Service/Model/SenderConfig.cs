using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model
{
    public class SenderConfig
    {
        public string from_name { get; set; }
        public string from_phone { get; set; }
        public string from_address { get; set; }
        public string from_ward_name { get; set; }
        public string from_ward_code { get; set; }
        public string from_district_name { get; set; }
        public int from_district_id { get; set; }
        public string from_province_name { get; set; }
        public string return_phone { get; set; }
        public string return_address { get; set; }
    }
}
