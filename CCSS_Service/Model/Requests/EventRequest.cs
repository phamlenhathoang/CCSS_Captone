using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class EventRequest
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreateBy { get; set; }
        public TicketRequest Ticket { get; set; }

        //public ICollection<Image> Images { get; set; } = new List<Image>();
        //public ICollection<EventCharacter> EventCharacters { get; set; } = new List<EventCharacter>();
        //public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
    public class CreateEventRequest
    {
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        //public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CreateBy { get; set; }

        
        public ICollection<TicketRequest> Ticket { get; set; }

        public ICollection<EventCharacterRequest> EventCharacterRequest { get; set; } = new List<EventCharacterRequest>();
        public ICollection<EventActivityRequest> EventActivityRequests { get; set; } = new List<EventActivityRequest>();

    }
    public class UpdateEventRequest
    {
        public string? EventName { get; set; }
        public string? Description { get; set; }
        //public string? Location { get; set; }
        //public bool? IsActive { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public string? CreateBy { get; set; }
        //public ICollection<TicketRequest> Ticket { get; set; }
        //public ICollection<Image> Images { get; set; } = new List<Image>();
        //public ICollection<EventImageRequest> Images { get; set; } = new List<EventImageRequest>();
        public ICollection<EventImageDeletedRequest> ImagesDeleted { get; set; } = new List<EventImageDeletedRequest>();
        public ICollection<EventCharacterRequest> EventCharacterRequests { get; set; } = new List<EventCharacterRequest>();
        public ICollection<EventActivityRequest> EventActivityRequests { get; set; } = new List<EventActivityRequest>();

        //public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
