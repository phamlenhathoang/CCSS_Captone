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
        Task<Contract> GetContractAndContractCharacter(string id);
        Task<bool> AddContract(Contract contract);
        Task<bool> UpdateContract(Contract contract);
        Task<bool> DeleteContract(Contract contract);
      
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

        public async Task<bool> AddContract(Contract contract)
        {
             _context.Contracts.Add(contract);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContract(Contract contract)
        {
            _context.Contracts.Update(contract);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteContract(Contract contract)
        {
            _context.Contracts.Remove(contract);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Contract> GetContractAndContractCharacter(string id)
        {
            return await _context.Contracts.Include(c => c.ContractCharacters).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        }
    }
}
