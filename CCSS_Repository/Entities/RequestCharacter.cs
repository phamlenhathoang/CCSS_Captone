using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("RequestCharacter")]
    public partial class RequestCharacter
    {
        [Key]
        public string RequestCharacterId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Request")]
        public string RequestId { get; set; }   
        public Request Request { get; set; }

        [ForeignKey("CharacterId")]
        public string CharacterId { get; set; }
        public Character Character { get; set; } 
        public RequestCharacterStatus? status { get; set; }
        public string? reason { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }

        public ICollection<RequestDate> RequestDates { get; set; } = new List<RequestDate>();

        
    }

    public enum RequestCharacterStatus
    {
        None = 0,
        Accept = 1,
        Busy = 2,
        Cancel = 3,
    }
}
