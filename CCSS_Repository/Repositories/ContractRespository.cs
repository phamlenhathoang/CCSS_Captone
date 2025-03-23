using CCSS_Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        Task<List<Contract>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId);
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
            return await _context.Contracts.Include(c => c.ContractCharacters).Include(c => c.Request).ThenInclude(rc => rc.RequestCharacters).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
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
            return await _context.Contracts.Include(r => r.Request).ToListAsync();
        }

        public async Task<Contract> GetContractByIdThenIncludeFeedback(string id)
        {
            return await _context.Contracts.Include(c => c.ContractCharacters).ThenInclude(f => f.Feedback).FirstOrDefaultAsync(sc => sc.ContractId.Equals(id));
        }

        public Task<List<Contract>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId)
        {
            IQueryable<Contract> query = _context.Contracts.Include(r => r.Request).Include(cc => cc.ContractCharacters);

            if (!string.IsNullOrEmpty(contractName))
            {
                query = query.Where(c => c.ContractName.Contains(contractName));
            }

            if (!string.IsNullOrEmpty(contractStatus))
            {
                query = query.Where(c => c.ContractName.ToLower().ToString().Contains(contractName.ToLower()));
            }

            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime date = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(c => c.Request.StartDate.Date >= date);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime date = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                query = query.Where(c => c.Request.EndDate.Date <= date);
            }

            if (!string.IsNullOrEmpty(accountId))
            {
                query = query.Where(c => c.CreateBy.Equals(accountId));
            }

            if (!string.IsNullOrEmpty(contractId))
            {
                query = query.Where(c => c.ContractId.Equals(contractId));
            }

            return query.ToListAsync();
        }

    }
}
