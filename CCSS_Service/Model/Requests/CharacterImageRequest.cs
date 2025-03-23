using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CharacterImageRequest
    { 
        public string? CharactetImageId {  get; set; }
        public IFormFile? Image {  get; set; }
    }
}
