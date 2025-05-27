using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class LocationResponse
    {
        public string? LocationId { get; set; } 

        public string Address { get; set; }
        public int CapacityMin { get; set; }
        public int CapacityMax { get; set; }
    }
}
