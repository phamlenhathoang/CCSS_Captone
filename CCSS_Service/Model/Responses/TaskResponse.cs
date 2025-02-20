using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class TaskResponse
    {
        public string TaskId { get; set; }
        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }
        public Account Account { get; set; }

        public string? TaskName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Status { get; set; }

        [ForeignKey("EventId")]
        public string? EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("ContractId")]
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
