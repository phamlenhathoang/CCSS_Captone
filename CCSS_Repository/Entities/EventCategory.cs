using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("EventCategory")]
    public partial class EventCategory
    {
        [Key]
        public string EventCategoryId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public Event Event { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
