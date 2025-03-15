using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CharacterInRequest
    {
        public string RequestId { get; set; }    
        public string CharacterId { get; set; } 
        public double? TotalPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
    }
}
