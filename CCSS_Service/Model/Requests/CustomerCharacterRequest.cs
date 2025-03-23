using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CCSS_Service.Model.Requests
{
    public class CustomerCharacterRequest
    {
        public string CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
        public List<IFormFile> CustomerCharacterImages { get; set; }
    }
}
