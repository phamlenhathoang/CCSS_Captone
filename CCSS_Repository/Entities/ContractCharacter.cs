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
        [ForeignKey("ContractId")]
        public string ContracId { get; set; }   
        public virtual Contract Contract { get; set; }
        [ForeignKey("CharacterId")]
        public string CharacterId { get; set; }
        public virtual Character Character { get; set; } 
    }
}
