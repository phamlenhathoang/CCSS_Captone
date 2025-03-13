using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Services
{
    public interface IRequestServices
    {
        Task<List<Request>> GetAllRequest();
        Task<Request> GetRequestById(string id);
        Task<string> DeleteRequest(string id);
        Task<string> AddRequest(RequestDtos requestDtos);
    }
    public class RequestServices: IRequestServices
    {
        private readonly IRequestRepository _repository;

        public RequestServices(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Request>> GetAllRequest()
        {
            return await _repository.GetAllRequest();
        }

        public async Task<Request> GetRequestById(string id)
        {
            return await _repository.GetRequestById(id);
        }

        public async Task<string> AddRequest(RequestDtos requestDtos)
        {
           if (requestDtos == null)
            {
                return "Need fill request";
            }
            var newRequest = new Request()
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = requestDtos.AccountId,
                Name = requestDtos.Name,
                Description = RequestDescription.RentCosplayer,
                Price = requestDtos.Price,
                Status = RequestStatus.Pending,
                StartDate = requestDtos.StartDate,
                EndDate = requestDtos.EndDate,
                ServiceId = requestDtos.ServiceId,
                ContractId = null,
            };
            await _repository.AddRequest(newRequest);
            return "Add Request Success";
        }

        //public async Task UpdateRequest(Request request)
        //{
        //   await _repository.AddRequest(request);
        //}

        public async Task<string> DeleteRequest(string id)
        {
          var request = await GetRequestById(id);
            if (request == null)
            {
                return "Request not found";
            }
            await _repository.DeleteRequest(request);
            return "Delete Request Success";
        }


    }
}
