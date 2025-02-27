
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Contract")]
    public partial class Contract
    {
        [Key]
        public string ContractId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }
        public Account Account { get; set; }
        public string? ContractName { get; set; }
        public string? ContractCode { get; set; }    
        public string? Description { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public bool? Signature { get; set; }
        public string? Deposit { get; set; }
        public int? CharacterQuantity { get; set; }
        public string? Location { get; set; }
        public ContractStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("PackageId")]
        public string? PackageId { get; set; }
        public Package Package { get; set; }
        public Feedback Feedback { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<ContractCharacter> ContractCharacters { get; set; } = new List<ContractCharacter>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        
    }

    public enum ContractStatus
    {
        Pending,
        Browsed,
        Progressing,
        Completed,
        Cancel
    }

    public enum ContractDescription
    {
        RentCostumes,
        RentCosplayer,
        CreateEvent
    }
}
