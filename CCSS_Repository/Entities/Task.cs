using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Name { get; set; }    
        public DateTime CreateDate { get; set; }   
        public DateTime? UpdateDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AccountTask> AccountTasks { get; set; } = new List<AccountTask>();   
    }
}
