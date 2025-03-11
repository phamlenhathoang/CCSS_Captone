using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("EventActivity")]
    public partial class EventActivity
    {
        [Key]
        public string EventActivityId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("EventId")]
        public string? EventId { get; set; }
        public Event? Event { get; set; }

        [ForeignKey("ActivityId")]
        public string? ActivityId { get; set; }
        public Activity Activity { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CreateBy { get; set; }
    }
}
