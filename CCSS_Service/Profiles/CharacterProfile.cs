using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            //Response
            CreateMap<Character, CharacterResponse>()
            .ForMember(dest => dest.CreateDate,
                opt => opt.MapFrom(src => src.CreateDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src =>
                    src.UpdateDate.HasValue
                        ? src.UpdateDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : string.Empty))
            .ReverseMap();

        }
    }
}
