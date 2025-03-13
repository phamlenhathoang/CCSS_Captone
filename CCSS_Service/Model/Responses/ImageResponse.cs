using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ImageResponse
    {
        public string ImageId { get; set; } 
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        
        public string? ProductId { get; set; }
        //public Product Product { get; set; }

        public string? EventId { get; set; }
        //public Event Event { get; set; }

        public string? CharacterId { get; set; }
        //public Character Character { get; set; }
    }
    public partial class EventImageResponse
    {
        
        public string ImageId { get; set; } = Guid.NewGuid().ToString();
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        
        
    }
}
