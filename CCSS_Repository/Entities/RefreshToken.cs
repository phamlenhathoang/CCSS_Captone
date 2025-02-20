using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("RefreshToken")]
    public partial class RefreshToken
    {
        [Key]
        public string RefreshTokenId { get; set; } = Guid.NewGuid().ToString();   
        public string RefreshTokenValue {  get; set; }
        public string RefreshTokenCode {  get; set; }
        public string JwtId {  get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public Account Account { get; set; }    

    }
}
