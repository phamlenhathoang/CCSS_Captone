using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class AccountResponse
    {
        public string AccountId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string? Birthday { get; set; }
        public int? Phone { get; set; }
        public bool? IsActive { get; set; }
        public bool? OnTask { get; set; }
        public bool? Leader { get; set; }
        public string? Code { get; set; }
        public string? ImageUrl { get; set; }
        public int? TaskQuantity { get; set; }
    }

    public class AccountByCharacterAndDateResponse
    {
        public string AccountId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string? Birthday { get; set; }
        public int? Phone { get; set; }
        public bool? IsActive { get; set; }
        public bool? OnTask { get; set; }
        public bool? Leader { get; set; }
        public string? Code { get; set; }
        public string? ImageUrl { get; set; }
        public int? TaskQuantity { get; set; }
    }
}
