using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IEventService
    {
        Task<List<EventResponse>> GetEvents();
        Task<EventResponse> GetEventById(string eventId);
    }
    public class EventService : IEventService
    {
        private IMapper mapper;
        private IEventRepsository eventRepsository;

        public EventService(IEventRepsository repsository, IMapper mapper)
        {
            this.mapper = mapper;
            eventRepsository = repsository; 
        }

        public async Task<EventResponse> GetEventById(string eventId)
        {
            return mapper.Map<EventResponse>(await eventRepsository.GetEventById(eventId));
        }

        public async Task<List<EventResponse>> GetEvents()
        {
            return mapper.Map<List<EventResponse>>(await eventRepsository.GetEvents());
        }
    }
}
