using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class CategoryResponse
    {
        public string CategoryId { get; set; } = Guid.NewGuid().ToString();
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
