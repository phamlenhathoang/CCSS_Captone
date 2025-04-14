using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class RequestDateResponse
    {
        public string RequestDateId { get; set; }
        public string? RequestCharacterId { get; set; }
        public string? ContractCharacterId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Reason { get; set; }
        public RequestDateStatus? Status { get; set; }
    }
}
