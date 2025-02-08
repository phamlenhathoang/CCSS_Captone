using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Response
{
    public class AccountResponse
    {
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
     
        public int Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        //public RoleRespone Role { get; set; }
        //public ContractRespone Contract { get; set; }
        //public ImageRespone Image { get; set; }
    }
}
