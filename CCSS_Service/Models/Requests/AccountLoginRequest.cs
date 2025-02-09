using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Requests
{
    public class AccountLoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
    }
}
