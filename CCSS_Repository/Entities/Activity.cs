using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Activity")]
    public partial class Activity
    {
        [Key]
        public string? ActivityId {  get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<EventActivity> EventActivities { get; set; } = new List<EventActivity>();
    }
}
