using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class NotificationResponse
    {
        public string Id { get; set; } 
        public string AccountId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public bool IsSentMail { get; set; }
        public string CreatedAt { get; set; }
    }
}
