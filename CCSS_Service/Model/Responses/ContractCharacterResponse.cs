using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class ContractCharacterResponse
    {
        [Key]
        public string ContractCharacterId { get; set; } = Guid.NewGuid().ToString();

        public string CharacterId { get; set; }
        public string? ContractId { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string? Description { get; set; }
        public string? CosplayerId { get; set; }
        public int? Quantity { get; set; }
    }
}
