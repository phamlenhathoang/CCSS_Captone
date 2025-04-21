using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("ContractCharacter")]
    public partial class ContractCharacter
    {
        [Key]
        public string ContractCharacterId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("CharacterId")]
        public string CharacterId { get; set; }
        public Character Character { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }

        public double? TotalPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }

        public List<Task> Tasks { get; set; } = new List<Task> { };
        public Feedback Feedback { get; set; }
        public ICollection<RequestDate> RequestDates { get; set; } = new List<RequestDate>();
    }
}
