﻿using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model.Responses
{
    public class TaskResponse
    {
        public string TaskId { get; set; }
        public string? AccountId { get; set; }
        public string? TaskName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string? Status { get; set; }
        public string? EventId { get; set; }
        public string? ContractId { get; set; }
        public bool IsValidate { get; set; }
    }
}
