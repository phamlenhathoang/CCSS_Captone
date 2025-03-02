using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CharacterRequest
    {
        public string CategoryId { get; set; }
        public string? CharacterName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
