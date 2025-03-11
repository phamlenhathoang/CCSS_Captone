using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("EventCharacter")]
    public partial class EventCharacter
    {
        [Key]
        public string EventCharacterId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public Event Event { get; set; } 

        [ForeignKey("CharacterId")]
        public string CharacterId { get; set; }
        public Character Character { get; set; } 

        public Task Task { get; set; }
    }
}
