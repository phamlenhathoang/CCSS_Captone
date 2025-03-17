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
        Task<bool> AddContract(Contract contract);
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
            _context.Contracts.Add(contract);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
