using AutoMapper;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            //Response
            CreateMap<Task, TaskResponse>().ReverseMap();
        }
    }
}
