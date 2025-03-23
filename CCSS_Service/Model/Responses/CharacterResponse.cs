using CCSS_Repository.Entities;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CharacterResponse
    {
        public string CharacterId { get; set; }
        public string CategoryId { get; set; }
        public string? CharacterName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public List<CharacterImageResponse> Images { get; set; }
    }

    public class CharacterImageResponse
    {
        public string CharacterImageId { get; set; }
        public string UrlImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsAvatar { get; set; }
    }
}
