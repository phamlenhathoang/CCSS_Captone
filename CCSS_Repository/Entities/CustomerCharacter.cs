using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("CustomerCharacter")]
    public partial class CustomerCharacter
    {
        [Key]
        public string CustomerCharacterId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public CustomerCharacterStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }   
    }

    public enum CustomerCharacterStatus
    {
        Pending,
        Accept,
        Reject,
    }
}
