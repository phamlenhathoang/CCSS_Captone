﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class PackageResponse
    {
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
