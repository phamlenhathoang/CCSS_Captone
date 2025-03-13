using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class EventActivityRequest
    {
        //public string EventActivityId { get; set; } = Guid.NewGuid().ToString();

        
        //public string? EventId { get; set; }
        //public Event? Event { get; set; }

        public string? ActivityId { get; set; }
        //public Activity Activity { get; set; }

        //public DateTime? CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CreateBy { get; set; }
    }
}
