using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("RequestDate")]
    public class RequestDate
    {
        [Key]
        public string RequestDateId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("RequestCharacter")]
        public string? RequestCharacterId { get; set; }
        public RequestCharacter RequestCharacter { get; set; }

        [ForeignKey("ContractCharacter")]
        public string? ContractCharacterId { get; set; }
        public ContractCharacter ContractCharacter { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
