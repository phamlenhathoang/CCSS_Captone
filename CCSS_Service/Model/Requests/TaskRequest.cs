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
        public string AccountId { get; set; }
        public string CharacterName { get; set; }
    }
}
