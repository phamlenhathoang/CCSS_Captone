using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class NotificationRequest
    {
        public string AccountId { get; set; }  
        public string Message { get; set; }           
    }
}
