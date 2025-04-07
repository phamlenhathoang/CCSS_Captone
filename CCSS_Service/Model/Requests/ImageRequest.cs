using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class ImageRequest
    {
        public IFormFile ImageUrl { get; set; }    
        public string? ProductId { get; set; }    
        public string? EventId { get; set; }    
        public string? CharacterId { get; set; }
  
    }
    public class EventImageRequest
    {
        public IFormFile ImageUrl { get; set; }    
        
  
    }
    public class EventImageDeletedRequest
    {
        public string ImageId { get; set; } = Guid.NewGuid().ToString();

    }
}
