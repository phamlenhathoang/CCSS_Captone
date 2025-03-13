using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class EventActivitProfile : Profile
    {
        public EventActivitProfile() 
        {
            CreateMap<EventActivity, EventActivityResponse>()
               .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity))
               .ReverseMap();
            CreateMap<EventActivity, EventActivityRequest>().ReverseMap();

        }
    }
}
