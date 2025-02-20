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
    public interface IContractRespository
    {
        Task<List<Contract>> GetAllContract(string searchterm);
        Task<Contract> GetContractById(string id);
        Task AddContract(Contract contract);
        Task UpdateContract(Contract contract);
        Task DeleteContract(string contractId);
    }

    public class ContractRespository: IContractRespository
    {
        private readonly CCSSDbContext _context;

        public ContractRespository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contract>> GetAllContract(string searchterm)
        {
            if (string.IsNullOrWhiteSpace(searchterm))
            {
                return await _context.Contracts.ToListAsync();
            }
            return await _context.Contracts.Where(sc => sc.ContractName.Contains(searchterm)).OrderByDescending(sc => sc.ContractName).ToListAsync();
        }

        public async Task<Contract> GetContractById(string id)
        {
            return await _context.Contracts.FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        }

        public async Task AddContract(Contract contract)
        {
             _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContract(Contract contract)
        {
            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContract(string contractId)
        {
            var contract = await GetContractById(contractId);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Delete Success");
            }
        }
    }
}
