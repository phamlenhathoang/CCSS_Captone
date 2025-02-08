using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Models.Response
{
    public class CategoryResponse
    {
        public string CategoryId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }

        //public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
       
    }
}
