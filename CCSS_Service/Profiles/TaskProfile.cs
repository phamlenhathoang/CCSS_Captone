using AutoMapper;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            //Response
            CreateMap<Task, TaskResponse>()
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src =>
                    src.StartDate.HasValue
                        ? src.StartDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : string.Empty))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src =>
                    src.EndDate.HasValue
                        ? src.EndDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : string.Empty))
            .ForMember(dest => dest.CreateDate,
                opt => opt.MapFrom(src =>
                    src.CreateDate.HasValue
                        ? src.CreateDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : string.Empty))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src =>
                    src.UpdateDate.HasValue
                        ? src.UpdateDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : string.Empty))
            .ReverseMap();


            //Request
            CreateMap<Task, TaskRequest>().ReverseMap();
        }
    }
}
