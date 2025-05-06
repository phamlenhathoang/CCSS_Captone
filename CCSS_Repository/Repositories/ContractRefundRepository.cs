using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IContractRefundRepository
    {
        Task<bool> AddContractRefund(ContractRefund contractRefund);
        Task<ContractRefund> GetContractRefundByContractId(string contractId);
        Task<List<ContractRefund>> GetAllContractRefund();
        Task<ContractRefund> GetContractRefundByContractRefundId(string contractRefundId);
        Task<bool> UpdateContractRefund(ContractRefund contractRefund);
    }
    public class ContractRefundRepository : IContractRefundRepository
    {
        private readonly CCSSDbContext _dbContext;

        public ContractRefundRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddContractRefund(ContractRefund contractRefund)
        {
            await _dbContext.AddAsync(contractRefund);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<ContractRefund>> GetAllContractRefund()
        {
            return await _dbContext.ContractRefunds.ToListAsync();
        }

        public async Task<ContractRefund> GetContractRefundByContractId(string contractId)
        {
            return await _dbContext.ContractRefunds.Include(c => c.Contract).ThenInclude(c => c.Request).FirstOrDefaultAsync(c => c.ContractId.Equals(contractId));
        }

        public async Task<ContractRefund> GetContractRefundByContractRefundId(string contractRefundId)
        {
            return await _dbContext.ContractRefunds.FirstOrDefaultAsync(c => c.ContractRefundId.Equals(contractRefundId));
        }

        public async Task<bool> UpdateContractRefund(ContractRefund contractRefund)
        {
            _dbContext.Update(contractRefund);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
