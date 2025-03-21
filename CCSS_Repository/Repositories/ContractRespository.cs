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
        Task<Contract> GetContractById(string id);
        Task<Contract> GetContractByIdThenIncludeFeedback(string id);
        Task<bool> AddContract(Contract contract);
        Task<bool> UpdateContract(Contract contract);
        Task<List<Contract>> GetContracts();
    }

    public class ContractRespository: IContractRespository
    {
        private readonly CCSSDbContext _context;

        public ContractRespository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<Contract> GetContractById(string id)
        {
            return await _context.Contracts.Include(c => c.ContractCharacters).Include(c => c.Request).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        }

        public async Task<bool> AddContract(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContract(Contract contract)
        {
            _context.Contracts.Update(contract);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contract>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<Contract> GetContractByIdThenIncludeFeedback(string id)
        {
            return await _context.Contracts.Include(c => c.ContractCharacters).ThenInclude(f => f.Feedback).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        }
    }
}
