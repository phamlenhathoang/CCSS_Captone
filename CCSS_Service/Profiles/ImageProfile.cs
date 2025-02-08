using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile() 
        {
            CreateMap<Image, ImageResponse>(). ReverseMap();
        }
    }
}
