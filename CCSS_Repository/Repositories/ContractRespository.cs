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
        //Task<List<Request>> GetAllContract(string searchterm);
        //Task<Request> GetContractById(string id);
        //Task<Request> GetContractAndContractCharacter(string id);
        //Task<Contract> GetContractAndTasks(string contractId);
        //Task<bool> AddContract(Request contract);
        //Task<bool> UpdateContract(Request contract);
        //Task<bool> DeleteContract(Request contract);

    }

    public class ContractRespository: IContractRespository
    {
        private readonly CCSSDbContext _context;

        public ContractRespository(CCSSDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Request>> GetAllContract(string searchterm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchterm))
        //    {
        //        return await _context.Contracts.ToListAsync();
        //    }
        //    return await _context.Contracts.Where(sc => sc.ContractName.Contains(searchterm)).OrderByDescending(sc => sc.ContractName).ToListAsync();
        //}

        //public async Task<Request> GetContractById(string id)
        //{
        //    return await _context.Contracts.Include(c => c.ContractCharacters).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        //}

        //public async Task<bool> AddContract(Request contract)
        //{
        //    _context.Contracts.Add(contract);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdateContract(Request contract)
        //{
        //    _context.Contracts.Update(contract);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> DeleteContract(Request contract)
        //{
        //    _context.Contracts.Remove(contract);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<Request> GetContractAndContractCharacter(string id)
        //{
        //    return await _context.Contracts.Include(c => c.ContractCharacters).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        //}

        //public async Task<Contract> GetContractAndTasks(string contractId)
        //{
        //    return await _context.Contracts.Include(c => c.Tasks).FirstOrDefaultAsync(c => c.ContractId.Equals(contractId));
        //}
    }
}
