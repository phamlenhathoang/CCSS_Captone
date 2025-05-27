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
        public int participantQuantity { get; set; }
        public EventStatus? Status { get; set; }
        public string? CreateBy { get; set; }
        public ICollection<TicketResponse> Ticket { get; set; }
        public ICollection<EventImageResponse> EventImageResponses { get; set; } = new List<EventImageResponse>();
        public List<EventCharacterResponse> EventCharacterResponses { get; set; } = new List<EventCharacterResponse>();
        public List<EventActivityResponse> EventActivityResponse { get; set; } = new List<EventActivityResponse>();
    }
    public class EventticketResponse
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
        
    }
}
