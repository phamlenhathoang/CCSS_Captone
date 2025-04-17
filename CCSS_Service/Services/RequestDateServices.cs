using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IRequestDateServices
    {
        Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId);
        Task<decimal> CaculateTotalHourInRequestDate(string requestDateId);
        Task<decimal> CaculateTotalHour(string requestCharacterId);
        Task<RequestDate> GetRequestDate(string id);
    }
    public class RequestDateServices : IRequestDateServices
    {
        private readonly IRequestDatesRepository _requestDatesRepository;

        public RequestDateServices(IRequestDatesRepository requestDatesRepository)
        {
            _requestDatesRepository = requestDatesRepository;
        }

        public async Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId)
        {
            return await _requestDatesRepository.GetListRequestDateByRequestCharacter(requestCharacterId);
        }

        public async Task<RequestDate> GetRequestDate(string id)
        {
            return await _requestDatesRepository.GetRequestDateById(id);
        }

        public async Task<decimal> CaculateTotalHour(string requestCharacterId)
        {
            var listRequestDate = await _requestDatesRepository.GetListRequestDateByRequestCharacter(requestCharacterId);
            if (listRequestDate == null)
            {
                throw new Exception("Request date is not found");
            }
            else
            {
                decimal totalHour = 0;
                foreach (var item in listRequestDate)
                {
                    TimeSpan duration = item.EndDate - item.StartDate;
                    totalHour += (decimal)duration.TotalHours;
                }
                return totalHour;
            }
        }

        public async Task<decimal> CaculateTotalHourInRequestDate(string requestDateId)
        {
            var requestDate = await _requestDatesRepository.GetRequestDateById(requestDateId);
            if (requestDate == null)
            {
                throw new Exception("Request date is not found");
            }
            else
            {
                decimal totalHour = 0;

                TimeSpan duration = requestDate.EndDate - requestDate.StartDate;
                totalHour += (decimal)duration.TotalHours;

                return totalHour;
            }
        }
    }
}
