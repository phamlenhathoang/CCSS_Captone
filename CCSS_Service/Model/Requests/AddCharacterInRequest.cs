using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class AddCharacterInRequest
    {
        public string RequestId { get; set; }
        public string CharacterId { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }
        public List<AddRequestDate> AddRequestDates { get; set; }
    }

    public class AddRequestDate
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
