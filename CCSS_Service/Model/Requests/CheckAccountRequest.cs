using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CheckAccountRequest
    {
        public string CharacterId { get; set; }
        public List<Date> Dates { get; set; }
        public string? AccountId { get; set; }
    }

    public class Date
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class CheckAccountRequestForRange
    {
        public string CharacterId { get; set; }
        public List<Date> Dates { get; set; }
        public string RequestId { get; set; }
    }
}
