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
        public string RoleId { get; set; } = Guid.NewGuid().ToString();
        public RoleEnum RoleName { get; set; }
        public string? Description { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();   
    }

    public enum RoleEnum
    {
        Admin,
        Manager,
        Customer,
        Cosplayer,
        Consultant,
    }
}
