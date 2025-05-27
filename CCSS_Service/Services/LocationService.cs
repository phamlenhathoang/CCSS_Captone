using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ILocationService
    {
        Task<List<LocationResponse>> GetAllLocations();
        Task<LocationResponse> GetLocationById(string locationId);
        Task<bool> AddLocation(LocationRequest location);
        //Task<bool> UpdateLocation(LocationRequest location);
        Task<bool> DeleteLocation(string locationid);
    }
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationResponse>> GetAllLocations()
        {
            var locations = await _locationRepository.GetAllLocations();
            return _mapper.Map<List<LocationResponse>>(locations);
        }

        public async Task<LocationResponse> GetLocationById(string locationId)
        {
            var location = await _locationRepository.GetLocationById(locationId);
            if (location == null) return null;

            return _mapper.Map<LocationResponse>(location);
        }

        public async Task<bool> AddLocation(LocationRequest locationRequest)
        {
            var location = _mapper.Map<Location>(locationRequest);
            location.LocationId = Guid.NewGuid().ToString();
            return await _locationRepository.AddLocation(location);
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            return await _locationRepository.UpdateLocation(location);
        }

        public async Task<bool> DeleteLocation(string locationId)
        {
            var location = await _locationRepository.GetLocationById(locationId);
            if (location == null) return false;

            return await _locationRepository.DeleteLocation(location);
        }
    }

}
