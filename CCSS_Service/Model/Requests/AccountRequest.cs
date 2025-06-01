using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class AccountRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class UpdateAccountRequest
    {
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string? Birthday { get; set; }
        public string? Phone { get; set; }
        public IFormFile? Avatar { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? UserName { get; set; }
        public List<IFormFile>? Images { get; set; }
    }

    public class CreateAccountRequest
    {
        public double? SalaryIndex { get; set; }
        public string? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Birthday { get; set; }
        public string? Phone { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
    }
}
