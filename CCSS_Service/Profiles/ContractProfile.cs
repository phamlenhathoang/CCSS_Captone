using AutoMapper;
using CCSS_Service.Models.Response;
using CCSS_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile() 
        {
            CreateMap<CCSS_Repository.Entities.Contract, ContractResponse>().ReverseMap();
        }
    }
}
