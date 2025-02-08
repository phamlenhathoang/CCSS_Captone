using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Response
{
    public class ImageResponse
    {
        public string ImageId { get; set; } = Guid.NewGuid().ToString();
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? AccountId { get; set; }
        public string? CharacterId { get; set; }
    }
}
