using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Event")]

    public partial class Event
    {
        [Key]
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
        public EventStatus? Status { get; set; }

        [ForeignKey("LocationId")]
        public string? LocationId { get; set; }
        public Location LocationEvent { get; set; }
        public ICollection<Ticket> Ticket { get; set; }

        
        public ICollection<EventImage> EventImages { get; set; } = new List<EventImage>();
        public ICollection<EventCharacter> EventCharacters { get; set; } = new List<EventCharacter>();  
        public ICollection<EventActivity> EventActivities { get; set; } = new List<EventActivity>();    
    }

    public enum EventStatus
    {
        Pending,
        StopSell,
        Progressing,
        Completed,
    }
}
