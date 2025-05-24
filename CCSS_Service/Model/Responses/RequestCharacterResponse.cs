using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class RequestCharacterResponse
    {
        public string RequestCharacterId { get; set; }
        public string RequestId { get; set; }
        public string CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public RequestCharacterStatus? Status { get; set; }
        public string? Reason { get; set; }
        public double? TotalPrice { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }
        public List<RequestDateResponse> RequestDateInCharacterResponses { get; set; }
    }

    public class RequestCharacterDateResponse
    {
        public string RequestCharacterId { get; set; } 
        public string RequestId { get; set; }
        public string CharacterId { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public double? TotalPrice { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }
    }
}
