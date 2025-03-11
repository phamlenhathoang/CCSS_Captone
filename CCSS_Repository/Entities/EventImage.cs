using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("EventImage")]

    public partial class EventImage
    {
        [Key]
        public string ImageId { get; set; } = Guid.NewGuid().ToString();    
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("EventId")]
        public string? EventId { get; set; }
        public Event Event { get; set; }
    }
}
