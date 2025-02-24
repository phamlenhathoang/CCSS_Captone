using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class EventResponse
    {
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreateBy { get; set; }
        public TicketResponse Ticket { get; set; }
        //public ICollection<Image> Images { get; set; } = new List<Image>();
        public List<EventCharacterResponse> EventCharacterResponses { get; set; } = new List<EventCharacterResponse>();
        //public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
