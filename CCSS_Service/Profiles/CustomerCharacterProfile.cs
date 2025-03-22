using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class CustomerCharacterProfile : Profile
    {
        public CustomerCharacterProfile() 
        {
            //Request 
            CreateMap<CustomerCharacter, CustomerCharacterRequest>().ReverseMap();
        }
    }
}
