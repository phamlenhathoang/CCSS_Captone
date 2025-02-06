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
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có đúng 10 chữ số.")]
        public int Phone {  get; set; }
        public DateTime? Birthday { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Email {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
        public Role Role { get; set; }

        public Contract Contract { get; set; }
        public Image Image { get; set; }

        public ICollection<AccountTask> AccountTasks { get; set; } = new List<AccountTask>();   
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
