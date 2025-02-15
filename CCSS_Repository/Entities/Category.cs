﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        public string CategoryId { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
        public ICollection<Character> Characters { get; set; } = new List<Character>(); 
    }
}
