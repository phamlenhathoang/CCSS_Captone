using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
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

        
    }
}
