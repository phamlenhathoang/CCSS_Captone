using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class AddTaskRequest
    {
        public string CharacterId { get; set; }
        public int QuantityCharacter {  get; set; }
        public List<string> AccountIds { get; set; }
        public string ContractId { get; set; }
    }
}
