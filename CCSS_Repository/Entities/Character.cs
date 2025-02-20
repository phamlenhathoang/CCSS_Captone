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
        private string? Description { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>(); 
        public ICollection<EventCharacter> EventCharacters { get; set; } = new List<EventCharacter>(); 
        public ICollection<ContractCharacter> ContractCharacters { get; set; } = new List<ContractCharacter>(); 
    }
}
