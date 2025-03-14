using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class RequestDtos
    {
        public string RequestId { get; set; } = Guid.NewGuid().ToString();

    
        public string? AccountId { get; set; }

        public string Name { get; set; }
        public RequestDescription? Description { get; set; }
        public double? Price { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }           
        public string? ServiceId { get; set; }          
        public string? ContractId { get; set; }
          
    }
}
