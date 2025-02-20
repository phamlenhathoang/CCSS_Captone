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
    public interface IPackageService
    {
        Task<PackageResponse> GetPackage(string packageId);
        Task<List<PackageResponse>> GetAll();
    }
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper mapper;

        public PackageService(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            this.mapper = mapper;
        }

        public async Task<List<PackageResponse>> GetAll()
        {
            return mapper.Map<List<PackageResponse>>( await _packageRepository.GetAll());
        }

        public async Task<PackageResponse> GetPackage(string packageId)
        {
            return mapper.Map<PackageResponse>(await _packageRepository.GetPackage(packageId));
        }
    }
}
