using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("CustomerCharacterImage")]
    public class CustomerCharacterImage
    {
        [Key]
        public string CustomerCharacterImageId { get; set; } = Guid.NewGuid().ToString();
        public string UrlImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("CustomerCharacterId")]
        public string? CustomerCharacterId { get; set; }
        public CustomerCharacter CustomerCharacter { get; set; }
    }
}
