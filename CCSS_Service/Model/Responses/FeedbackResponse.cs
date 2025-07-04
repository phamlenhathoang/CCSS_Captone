﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class FeedbackResponse
    {
        public int? Star { get; set; }
        public string? Description { get; set; }
        public string? AccountId { get; set; }
    }

    public class FeedbackResponseByCosplayerId
    {
        public int? Star { get; set; }
        public string? Description { get; set; }
        public string? AccountName { get; set; }
        public string? CharacterName {  get; set; }
    }
}
