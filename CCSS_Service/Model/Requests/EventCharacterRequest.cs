using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class EventCharacterRequest
    {

        //public string EventId { get; set; }

        public string CharacterId { get; set; }
    }
}
