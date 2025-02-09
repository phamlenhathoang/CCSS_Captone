using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Responses
{
    public class EventResponse
    {
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public EventStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Contract Contract { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
    }
}
