
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Request")]
    public partial class Request
    {
        [Key]
        public string RequestId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }
        public Account Account { get; set; }
        
        public string Name { get; set; }
        public RequestDescription? Description { get; set; }
        public double? Price { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("CouponId")]
        public string? CouponId { get; set;}
        public Coupon Coupon { get; set; }


        [ForeignKey("ServiceId")]
        public string? ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }

        public ICollection<RequestCharacter> RequestCharacters { get; set; } = new List<RequestCharacter>();
        
    }

    public enum RequestStatus
    {
        Pending,
        Browsed,
        Cancel
    }

    public enum RequestDescription
    {
        RentCostumes,
        RentCosplayer,
        CreateEvent
    }
}
