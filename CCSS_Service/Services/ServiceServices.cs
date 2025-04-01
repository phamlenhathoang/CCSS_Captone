using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IServiceServices
    {
        Task<List<ServiceResponse>> GetAllServices();
        Task<ServiceResponse> GetServiceById(string servicesId);
    }


    public class ServiceServices: IServiceServices
    {
        private readonly IServiceRepository _repository;
        public ServiceServices(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ServiceResponse>> GetAllServices()
        {

            List<ServiceResponse> serviceResponses = new List<ServiceResponse>();
            var listServices = await _repository.GetAllService();
            foreach(var s in listServices)
            {
                ServiceResponse serviceResponse = new ServiceResponse()
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.ServiceName,
                    Description = s.Description,
                    CreateDate = s.CreateDate,
                    UpdateDate = s.UpdateDate,
                };
                serviceResponses.Add(serviceResponse);
            }
            return serviceResponses;
        }

        public async Task<ServiceResponse> GetServiceById(string servicesId)
        {
            var service = await _repository.GetService(servicesId);
            ServiceResponse serviceResponse = new ServiceResponse()
            {
                ServiceId = service.ServiceId,
                ServiceName = service.ServiceName,
                Description= service.Description,
                CreateDate = service.CreateDate,
                UpdateDate = service.UpdateDate,
            };

            return serviceResponse;
        }
    }
}
