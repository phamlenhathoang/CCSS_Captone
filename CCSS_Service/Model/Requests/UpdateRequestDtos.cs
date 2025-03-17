using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class UpdateRequestDtos
    {             
            public string Name { get; set; }
            //public RequestDescription? Description { get; set; }       
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string? Location { get; set; }
            public string? ServiceId { get; set; }
            public List<UpdateCharacterList> ListUpdateRequestCharacters { get; set; }

       
        public class UpdateCharacterList
        {
            public string CharacterId { get; set; }
            public string? CosplayerId { get; set; }
            public string? Description { get; set; }
            public int? Quantity { get; set; }
        }
    }
}
