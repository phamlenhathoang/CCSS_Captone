using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class PackageRequest
    {
        public string PackageName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
