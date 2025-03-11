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
        public string? TaskName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public TaskStatus? Status { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("EventCharacterId")]
        public string EventCharacterId { get; set; }
        public EventCharacter EventCharacter { get; set; }

        [ForeignKey("ContractCharacterId")]
        public string? ContractCharacterId { get; set; }
        public ContractCharacter ContractCharacter { get; set; } 
    }

    public enum TaskStatus
    {
        Pending,
        Assignment,
        Progressing,
        Completed,
        Cancel
    }
}
