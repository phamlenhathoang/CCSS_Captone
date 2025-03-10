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
        public string? Phone { get; set; }
        public bool? IsActive {  get; set; }
        public bool? OnTask {  get; set; }
        public bool? Leader {  get; set; }   
        public string? Code {  get; set; }
        public string? ImageUrl {  get; set; }
        public int? TaskQuantity { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
        public Role Role { get; set; } 
        public Cart Cart { get; set; }
        public EventCharacter EventCharacter { get; set; }
        public ContractCharacter ContractCharacter { get; set; }
        public ICollection<TicketAccount> TicketAccounts { get; set; } = new List<TicketAccount>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();    
        public ICollection<AccountCoupon> AccountCoupons { get; set; } = new List<AccountCoupon>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
