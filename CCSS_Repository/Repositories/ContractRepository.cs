using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllContract(string searchterm);
        Task<Contract> GetContractById(string contractId);
        Task AddContract(Contract contract);
        Task DeleteContract(string contractId);
        Task UpdateContract(Contract contract);
    }

    public class ContractRepository : IContractRepository
    {
        private readonly CCSSDBContext _dbContext;

        public ContractRepository(CCSSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contract>> GetAllContract(string searchterm)
        {
            if (string.IsNullOrEmpty(searchterm))
            {
                return await _dbContext.Contracts.ToListAsync();
            }
            return await _dbContext.Contracts.Where(sc => sc.Name.Contains(searchterm)).ToListAsync();
        }

        public async Task<Contract> GetContractById(string contractId)
        {
            return await _dbContext.Contracts.FirstOrDefaultAsync(sc => sc.ContractId.Equals(contractId));
        }

        public async Task AddContract(Contract contract)
        {
            _dbContext.Contracts.Add(contract);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteContract(string contractId)
        {
            var contract = await GetContractById(contractId);
            if (contract != null)
            {
                _dbContext.Contracts.Remove(contract);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateContract(Contract contract)
        {
            _dbContext.Contracts.Update(contract);
            await _dbContext.SaveChangesAsync();
        }
    }
}
