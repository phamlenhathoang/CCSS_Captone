using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class ContractImageRequest
    {
        public string? ContractId { get; set; }
        public IFormFile UrlImage { get; set; }
        public string? Status { get; set; }
    }
}
