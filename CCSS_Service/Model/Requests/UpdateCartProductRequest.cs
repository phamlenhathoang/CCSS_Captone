using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class UpdateCartProductRequest
    {
        public string CartProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
