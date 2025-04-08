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
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface IPackageService
    {
        Task<PackageResponse> GetPackage(string packageId);
        Task<Package> GetPackageById(string id);
        Task<List<PackageResponse>> GetAll();
        Task<string> AddPackage(PackageRequest packageResponse);
        Task<string> UpdatePackage(string packageId, PackageRequest newPackage);
        Task<string> DeletePackage(string packageId);
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
            return mapper.Map<List<PackageResponse>>(await _packageRepository.GetAll());
        }

        public async Task<PackageResponse> GetPackage(string packageId)
        {
            return mapper.Map<PackageResponse>(await _packageRepository.GetPackage(packageId));
        }

        public async Task<Package> GetPackageById(string id)
        {
            return await _packageRepository.GetPackage(id);
        }

        public async Task<string> AddPackage(PackageRequest packageResponse)
        {
            if (packageResponse == null)
            {
                return "Data is null here";
            }
            else
            {
                var newPackage = new Package()
                {
                    PackageId = Guid.NewGuid().ToString(),
                    PackageName = packageResponse.PackageName,
                    Description = packageResponse.Description,
                    Price = packageResponse.Price,
                };

                var result = await _packageRepository.AddPackage(newPackage);
                return result ? "Create package Success" : "Create package failed";
            }
        }

        public async Task<string> UpdatePackage(string packageId, PackageRequest newPackage)
        {
            var package = await GetPackageById(packageId);
            if (package == null)
            {
                return "this Package not found";
            }
            else
            {
                package.PackageName = newPackage.PackageName;
                package.Description = newPackage.Description;
                package.Price = newPackage.Price;

                var result = await _packageRepository.UpdatePackage(package);
                return result ? "Update Success" : "Update Failed";
            }
        }

        public async Task<string> DeletePackage(string packageId)
        {
            var package = await GetPackageById(packageId);
            if (package == null)
            {
                return "This Package is not found";
            }
            else
            {
                var result = await _packageRepository.DeletePackage(package);
                return result ? "Delete Success" : "Delete Failed";
            }

        }
    }
}
