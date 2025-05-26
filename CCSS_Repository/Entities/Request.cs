
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
        public string? Description { get; set; }
        public double? Price { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string? Range { get; set; }
        public string? Deposit { get; set; }
        public string? Reason { get; set; }

        [ForeignKey("ServiceId")]
        public string? ServiceId { get; set; }
        public Service Service { get; set; }
       

        [ForeignKey("PackageId")]
        public string? PackageId { get; set; }
        public Package Package { get; set; }

        //[ForeignKey("AccountCouponId")]
        //public string? AccountCouponId { get; set; }
        //public AccountCoupon AccountCoupon { get; set; }
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
