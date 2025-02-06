using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    [Table("Contract")]
    public partial class Contract
    {
        [Key]
        public string ContractId { get; set; } = Guid.NewGuid().ToString();

    }
}
