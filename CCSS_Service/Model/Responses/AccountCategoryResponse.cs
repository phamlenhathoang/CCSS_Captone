using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class AccountCategoryResponse
    {
        public string CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? CharacterId { get; set; }
        public string? Character {  get; set; }
        public List<AccountResponse> AccountResponses { get; set; }
    }
}
