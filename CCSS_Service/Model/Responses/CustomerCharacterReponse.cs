using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CustomerCharacterReponse
    {
        public string CustomerCharacterId { get; set; }
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public string? Status { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? Reason { get; set; }
        public ICollection<CustomerCharacterImageResponse>? CustomerCharacterImageResponses { get; set; } = new List<CustomerCharacterImageResponse>();
    }

    public class CustomerCharacterImageResponse
    {
        public string CustomerCharacterImageId { get; set; }
        public string UrlImage { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
    }
}
