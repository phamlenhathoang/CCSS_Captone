using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("AccountTask")]
    public partial class AccountTask
    {
        [Key]
        public string AccountTaskId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("TaskId")]        
        public string TaskId { get; set; }  
        public Task Task { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
