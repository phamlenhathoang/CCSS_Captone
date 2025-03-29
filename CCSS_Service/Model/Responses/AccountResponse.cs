using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double? AverageStar { get; set; }
        public string? Description { get; set; }
        public string? Birthday { get; set; }
        public int? Phone { get; set; }
        public bool? IsActive { get; set; }
        public bool? OnTask { get; set; }
        public bool? Leader { get; set; }
        public string? Code { get; set; }
        //public string? ImageUrl { get; set; }
        public int? TaskQuantity { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public double? SalaryIndex { get; set; }
        public List<AccountImageResponse>? Images { get; set; }
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
        public List<AccountImageResponse>? Images { get; set; }
        public int? TaskQuantity { get; set; }
        public int? TaskQuantity { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public double? SalaryIndex { get; set; }
    }
    public class AccountDashBoardResponse
    {
        public string AccountId { get; set; } 
        public string? Name { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public bool? OnTask { get; set; }
        public bool? Leader { get; set; }
        public string? Code { get; set; }
        public int? TaskQuantity { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public double? AverageStar { get; set; }
        public double? SalaryIndex { get; set; }
        public ICollection<AccountImageResponse> AccountImages { get; set; } = new List<AccountImageResponse>();
    }

}
