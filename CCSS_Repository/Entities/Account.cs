using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Account")]
    public partial class Account
    {
        [Key]
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Phone {  get; set; }
        public bool? IsActive {  get; set; }
        public bool? OnTask {  get; set; }
        public bool? Leader {  get; set; }   
        public string? Code {  get; set; }
        public string? ImageUrl {  get; set; }
        public int? TaskQuantity { get; set; }

        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
        public Role Role { get; set; } 
        public RefreshToken RefreshToken { get; set; }  
        public Cart Cart { get; set; }
        public ICollection<AccountCategory> AccountCategories { get; set; } = new List<AccountCategory>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
