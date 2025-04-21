using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class RequestResponse
    {
        public string RequestId { get; set; } = Guid.NewGuid().ToString();    
        public string? AccountId { get; set; }   
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Location { get; set; }     
        public string? ServiceId { get; set; }
        public string? PackageId { get; set; }
        public string? Deposit { get; set; }
        public string? Reason { get; set; }
        public int? TotalDate { get; set; }
        public string? AccountCouponId { get; set; }
        public List<CharacterRequestResponse> CharactersListResponse { get; set; } 
    }

    public class CharacterRequestResponse
    {
        public string RequestCharacterId { get; set; }
        public string CharacterId { get; set; }
        public string? CosplayerId { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public string? Status { get; set; }
        public ICollection<CharacterImageDto> CharacterImages { get; set; }

        public List<RequestDateResponse> RequestDateResponses { get; set; }
    }

    public class CharacterImageDto
    {
        public string CharacterImageId { get; set; }
        public string UrlImage { get; set; }
    }
}
