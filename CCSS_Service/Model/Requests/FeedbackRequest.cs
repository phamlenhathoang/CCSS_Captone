using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class FeedbackRequest
    {
        public string ContractCharacterId { get; set; }
        public int? Star { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateFeedbackRequest
    {
        public string FeedbackId { get; set; }
        public int? Star { get; set; }
        public string? Description { get; set; }
    }
}
