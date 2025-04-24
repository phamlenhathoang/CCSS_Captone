using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = CCSS_Repository.Entities.TaskStatus;

namespace CCSS_Service.Model.Requests
{
    public class TaskRequest
    {
        public List<AddTaskEventRequest>? AddTaskEventRequests { get; set; }
        public List<AddTaskContractRequest>? AddTaskContractRequests { get; set; }
    }

    public class AddTaskEventRequest
    {
        public string AccountId { get; set; }
        public string EventCharacterId { get; set; }
    }

    public class AddTaskContractRequest
    {
        public string CosplayerId { get; set; }
        public string RequestCharacterId { get; set; }
    }
}
