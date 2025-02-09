using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Models.Request;
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
        Task<string> AddContract(ContractResponse contractResponse);
        Task<string> UpdateContract(string contractId, ContractRequest contractRequest);
        Task DeleteContract(string contractId);
    }


    public class ContractServices : IContractServices
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

        public async Task<string> AddContract(ContractResponse contractResponse)
        {
            if (contractResponse == null)
            {
                throw new Exception("Data is null");

            }
            var contract = new Contract()
            {
                ContractId = Guid.NewGuid().ToString(),
                AccountId = contractResponse.AccountId,
                EventId = contractResponse.EventId,
                Name = contractResponse.Name,
                Description = contractResponse.Description,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                Price = contractResponse.Price,
                Deposit = contractResponse.Deposit,
                Amount = contractResponse.Amount,
            };
            await _contractRepository.AddContract(contract);
            return "Create Contract Success";
        }

        public async Task<string> UpdateContract(string contractId, ContractRequest contractRequest)
        {
            var contract = await _contractRepository.GetContractById(contractId);
            if (contract == null)
            {
                return "This contract is not existed";
            }
            contract.Name = contractRequest.Name;
            contract.Description = contractRequest.Description;
            contract.UpdateDate = DateTime.Now;
            contract.Price = contractRequest.Price;
            contract.Deposit = contractRequest.Deposit;
            contract.Amount = contractRequest.Amount;
            await _contractRepository.UpdateContract(contract);
            return "Update contract Success";
        }

        public async Task DeleteContract(string contractId)
        {
            await _contractRepository.DeleteContract(contractId);
        }
    }
}
