using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class RequestDtos
    {   
        public string? AccountId { get; set; }
        public string Name { get; set; }
        //public RequestDescription? Description { get; set; }
        public double? Price { get; set; }      
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Location { get; set; }
        public string? ServiceId { get; set; }
        public string? PackageId { get; set; }
        public List<CharacterList> ListRequestCharacters { get; set; }

    }

    public class CharacterList
    {
        public string CharacterId { get; set; }
        public string? CosplayerId { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
    }

    public class RequestPdf
    {
        public string? AccountId { get; set; }
        public Account Account { get; set; }

        public string Name { get; set; }
        public RequestDescription? Description { get; set; }
        public double? Price { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }


        [ForeignKey("ServiceId")]
        public string? ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }

        [ForeignKey("AccountCouponId")]
        public string? AccountCouponId { get; set; }
        public AccountCoupon AccountCoupon { get; set; }
    }
}
