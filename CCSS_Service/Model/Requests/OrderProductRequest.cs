﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class OrderProductRequest
    {
        

        public string ProductId { get; set; }


        
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
