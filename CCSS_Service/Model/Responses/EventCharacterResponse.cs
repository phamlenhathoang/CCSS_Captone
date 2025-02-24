using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class EventCharacterResponse
    {
        public string EventCharacterId { get; set; } = Guid.NewGuid().ToString();


        public string CharacterId { get; set; }
    }
}
