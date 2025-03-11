using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Character")]

    public partial class Character
    {
        [Key]
        public string CharacterId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("CategoryId")]
        public string? CategoryId { get; set; }
        public Category Category { get; set; }  
        public string? CharacterName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<EventCharacter> EventCharacters { get; set; } = new List<EventCharacter>(); 
        public ICollection<RequestCharacter> RequestCharacters { get; set; } = new List<RequestCharacter>(); 
        public ICollection<ContractCharacter> ContractCharacters { get; set; } = new List<ContractCharacter>(); 
        public ICollection<CharacterImage> CharacterImages { get; set; } = new List<CharacterImage>(); 
    }
}
