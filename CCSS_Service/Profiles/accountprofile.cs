﻿using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Service.Models.Requests;
using CCSS_Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            //Responses
            CreateMap<Account, AccountResponse>(). ReverseMap();

            //Requests
            CreateMap<Account, AccountLoginRequest>(). ReverseMap();
        }
    }
}
