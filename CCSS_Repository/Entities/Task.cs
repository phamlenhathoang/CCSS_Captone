using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Task")]

    public partial class Task
    {
        [Key]
        public string TaskId { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }    
        public string TaskName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public TaskStatus Status { get; set; }

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey("ContractId")]
        public string ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }

    public enum TaskStatus
    {
        Pending,
        Assignment,
        Progressing,
        Completed
    }
}
