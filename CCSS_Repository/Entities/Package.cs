using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Package")]
    public partial class Package
    {
        [Key]
        public string PackageId {  get; set; } = Guid.NewGuid().ToString();   
        public string? PackageName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
