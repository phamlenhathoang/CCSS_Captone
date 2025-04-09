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
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Response
            CreateMap<Product, CartProductRequestDTO>().ReverseMap();

            CreateMap<Product, ProductResponse>()
               .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
               .ReverseMap();
        }
    }
}
