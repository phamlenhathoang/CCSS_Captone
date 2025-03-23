using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("CharacterImage")]
    public partial class CharacterImage
    {
        [Key]
        public string CharacterImageId { get; set; } = Guid.NewGuid().ToString();
        public string UrlImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsAvatar { get; set; }

        [ForeignKey("CharacterId")]
        public string? CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
