using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Role")]
    public partial class Role
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public RoleName RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();   

    }

    public enum RoleName
    {
        Admin,
        Manager,
        Consultant,
        Cosplayer,
        Organizer,
        Customer,
    }
}
