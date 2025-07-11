﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class RequestDtos
    {   
        public string? AccountId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }      
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Location { get; set; }
        public string? Deposit { get; set; }
        public List<CharacterList> ListRequestCharacters { get; set; }

    }

    public class CharacterList
    {
        public string CharacterId { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        //public List<RequestDateDtos> ListRequestDates { get; set; }
    }

    public class RequestTotalPrice
    {
        public string? CosplayerId { get; set; }
        public string CharacterId { get; set; }
        public int Quantity { get; set; }
    }
}
