using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            //Response
            CreateMap<Account, AccountResponse>()
                    .ForMember(dest => dest.Birthday,
                        opt => opt.MapFrom(src =>
                            src.Birthday.HasValue
                                ? src.Birthday.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                : string.Empty))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.AccountImages))
                    .ReverseMap();


            CreateMap<Account, AccountByCharacterAndDateResponse>()
                    .ReverseMap();
            CreateMap<Account, AccountDashBoardResponse>()
                    .ReverseMap();
            CreateMap<AccountDashboard, top5AccountDashboardResponse>()
                    .ReverseMap();
            CreateMap<CosplayerPopular, CosplayerPopularResponse>()
                    .ReverseMap();


            //Request 
            CreateMap<Account, UpdateAccountRequest>().ReverseMap();
        }
    }
}