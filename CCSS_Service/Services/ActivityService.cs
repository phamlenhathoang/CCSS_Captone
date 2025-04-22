using AutoMapper;
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
    public interface IActivityService
    {
        Task<List<ActivityResponse>> GetAllActivities();
        Task<ActivityResponse> GetActivityById(string id);
        Task<bool> CreateActivity(Activity activity);
        Task<bool> UpdateActivity(Activity activity);
        Task<bool> DeleteActivity(string id);
    }
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<List<ActivityResponse>> GetAllActivities()
        {
            var activities = await _activityRepository.GetAllActivities();
            return _mapper.Map<List<ActivityResponse>>(activities);
        }

        public async Task<ActivityResponse> GetActivityById(string id)
        {
            var activity = await _activityRepository.GetActivityById(id);
            return activity == null ? null : _mapper.Map<ActivityResponse>(activity);
        }

        public async Task<bool> CreateActivity(Activity activity)
        {
            return await _activityRepository.AddActivity(activity);
        }

        public async Task<bool> UpdateActivity(Activity activity)
        {
            return await _activityRepository.UpdateActivity(activity);
        }

        public async Task<bool> DeleteActivity(string id)
        {
            var activity = await _activityRepository.GetActivityById(id);
            if (activity == null) return false;

            await _activityRepository.DeleteActivity(activity);
            return true;
        }
    }
}
