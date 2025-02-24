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
    public class EventProfile : Profile
    {
        public EventProfile() 
        {

            CreateMap<Event, EventResponse>().ReverseMap();
            CreateMap<Event, CreateEventRequest>().ReverseMap();
            CreateMap<Event, UpdateEventRequest>().ReverseMap();
            CreateMap<Event, EventRequest>().ReverseMap();
            CreateMap<Event, EventResponse>()
    .ForMember(dest => dest.EventCharacterResponses, opt => opt.MapFrom(src => src.EventCharacters)) // ✅ Đảm bảo mapping danh sách EventCharacters
    .ReverseMap();
        }
    }
}
