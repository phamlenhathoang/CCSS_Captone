using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class LocationRequest
    {

        public string Address { get; set; }
        public int CapacityMin { get; set; }
        public int CapacityMax { get; set; }
    }
}
