using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{

    public interface IContractServices
    {
        Task<List<Contract>> GetAll(string searchterm);
        Task<Contract> GetContractbyId(string contractId);
        Task AddContract(ContractResponse contractResponse);
        Task UpdateContract(ContractResponse contractResponse);
        Task DeleteContract(string contractId);
    }


    public class ContractServices: IContractServices
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractServices(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<List<Contract>> GetAll(string? searchterm)
        {
            return await _contractRepository.GetAllContract(searchterm);
        }

        public async Task<Contract> GetContractbyId(string contractId)
        {
            return await _contractRepository.GetContractById(contractId);
        }

        public async Task AddContract(ContractResponse contractResponse)
        {
             await _contractRepository.AddContract(_mapper.Map<Contract>(contractResponse));
        }

        public async Task UpdateContract(ContractResponse contractResponse)
        {
            await _contractRepository.UpdateContract(_mapper.Map<Contract>(contractResponse));
        }

        public async Task DeleteContract( string contractId)
        {
            await _contractRepository.DeleteContract(contractId);
        }
    }
}
