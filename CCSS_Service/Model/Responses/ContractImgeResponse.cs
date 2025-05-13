using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ContractImgeResponse
    {
        public string ContractImageId { get; set; } = Guid.NewGuid().ToString();
        public string ContractId { get; set; }

        public string UrlImage { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
