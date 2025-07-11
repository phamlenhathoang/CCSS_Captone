﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class RequestCreateEvent
    {
        public string? AccountId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Location { get; set; }
        public string? Deposit { get; set; }
        public string? PackageId { get; set; }
        public string? Range { get; set; }
        public List<CharacterRequestListCreateEvent> ListRequestCharactersCreateEvent { get; set; }

    }

    public class CharacterRequestListCreateEvent
    {
        public string CharacterId { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public List<RequestDateDtos> ListRequestDates { get; set; }
    }
}
