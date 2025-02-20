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
    public interface IContractServices
    {
        Task<List<Contract>> GetAllContract(string searchterm);
        Task<Contract> GetContract(string id);
        Task<string> AddContract(ContractRequest contractRequest);
        Task<string> UpdateContract(string contractId, ContractResponse contractResponse);
        Task DeleteContract(string id);

    }
    public class ContractServices: IContractServices
    {
        private readonly IContractRespository _respository;

        public ContractServices(IContractRespository respository)
        {
            _respository = respository;
        }

        public async Task<List<Contract>> GetAllContract(string? searchterm)
        {
            return await _respository.GetAllContract(searchterm);
        }

        public async Task<Contract> GetContract(string id)
        {
            return await _respository.GetContractById(id);
        }

        public async Task DeleteContract (string id)
        {
             await _respository.DeleteContract(id);
        }

        public async Task<string> AddContract(ContractRequest contractRequest)
        {
            if (contractRequest == null)
            {
                return "contract is null";
            }
            var newContract = new Contract()
            {
                ContractId = Guid.NewGuid().ToString(),
                AccountId = contractRequest.AccountId,
                PackageId = contractRequest.PackageId,
                ContractName = contractRequest.ContractName,
                ContractCode = contractRequest.ContractCode,
                Description = contractRequest.Description,
                Price = contractRequest.Price,
                Amount = contractRequest.Amount,
                Signature = contractRequest.Signature,
                Deposit = contractRequest.Deposit,
                Status = ContractStatus.Pending,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
               
            };
            await _respository.AddContract(newContract);
            return "Add Success";
        }

        public async Task<string> UpdateContract(string contractId, ContractResponse contractResponse)
        {
            var contractExicting = await _respository.GetContractById(contractId);
            if (contractExicting == null)
            {
                return "Contract is not found";
            }
            contractExicting.PackageId = contractResponse.PackageId;
            contractExicting.ContractName = contractResponse.ContractName;
            contractExicting.Description = contractResponse.Description;
            contractExicting.Price = contractResponse.Price;
            contractExicting.Amount = contractResponse.Amount;
            contractExicting.Signature = contractResponse.Signature;
            contractExicting.Deposit = contractResponse.Deposit;
            contractExicting.Status = contractResponse.Status;
            contractExicting.EndDate = DateTime.Now;

            await _respository.UpdateContract(contractExicting);
            return "Update Success";
        }
      
    }
}
