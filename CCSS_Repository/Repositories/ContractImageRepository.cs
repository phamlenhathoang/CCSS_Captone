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
    public interface IContractImageRepository
    {
        Task<bool> AddListContractImage(List<ContractImage> contractImages);
        Task<List<ContractImage>> GetContractImageByContractIdAndStatus(string contractId, string status);
        Task<ContractImage> GetContractImageByContractImageId(string contractImageId);
        Task<bool> UpdateContractImage(ContractImage contractImage);
        Task<bool> DeleteContractImage(ContractImage contractImage);
        Task<bool> AddContractImage(ContractImage contractImage);
        Task<List<ContractImage>> GetListContractImageByStatusRefundMoney();
    }
    public class ContractImageRepository : IContractImageRepository
    {
        private readonly CCSSDbContext _dbContext;

        public ContractImageRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddContractImage(ContractImage contractImage)
        {
            await _dbContext.AddAsync(contractImage);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> AddListContractImage(List<ContractImage> contractImages)
        {
            await _dbContext.AddRangeAsync(contractImages);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteContractImage(ContractImage contractImage)
        {
            _dbContext.ContractImages.Remove(contractImage);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<ContractImage>> GetContractImageByContractIdAndStatus(string contractId, string status)
        {
            return await _dbContext.ContractImages.Where(ci => ci.ContractId.Equals(contractId) && ci.Status.ToString().ToLower().Equals(status.ToLower())).ToListAsync();
        }

        public async Task<ContractImage> GetContractImageByContractImageId(string contractImageId)
        {
            return await _dbContext.ContractImages.FirstOrDefaultAsync(ci => ci.ContractImageId.Equals(contractImageId));
        }

        public async Task<List<ContractImage>> GetListContractImageByStatusRefundMoney()
        {
            return await _dbContext.ContractImages.Include(c => c.Contract).Where(c => c.Status.Equals(ContractImageStatus.RefundMoney)).ToListAsync();
        }

        public async Task<bool> UpdateContractImage(ContractImage contractImage)
        {
            _dbContext.ContractImages.Update(contractImage);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
