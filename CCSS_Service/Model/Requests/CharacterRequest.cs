﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Requests
{
    public class CharacterRequest
    {
        public string CategoryId { get; set; }
        public string? CharacterName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public float? MaxHeight { get; set; }
        public float? MaxWeight { get; set; }
        public float? MinHeight { get; set; }
        public float? MinWeight { get; set; }
    }

    public class DateCharacterRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
