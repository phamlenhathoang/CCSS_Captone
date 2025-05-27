using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("location")]
    public partial class Location
    {
        [Key]
        public string? LocationId { get; set; } = Guid.NewGuid().ToString();

        public string Address { get; set; }
        public int CapacityMin { get; set; }
        public int CapacityMax { get; set; }

        public ICollection<Event> Event { get; set; } = new List<Event>();
    }
}
