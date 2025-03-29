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
    public interface IContractCharacterRepository
    {
        //Task<RequestCharacter> GetContractCharacterById(string contractCharacterId);
        //Task AddCharacterInContract(RequestCharacter contractCharacter);
        //Task<bool> AddListCharacterInContract(List<RequestCharacter> contractCharacters);
        //Task UpdateChracterInContract(RequestCharacter contractCharacter);
        //Task DeleteChracterInContract(RequestCharacter contractCharacter);
        //Task<int> CountCharactersInContractAsync(string contractId);

        Task<ContractCharacter> GetContractCharacterById(string id);
        Task<bool> AddListContractCharacter(List<ContractCharacter> listContractCharacter);

    }
    public class ContractCharacterRepository : IContractCharacterRepository
    {
        private readonly CCSSDbContext _dbContext;

        public ContractCharacterRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddListContractCharacter(List<ContractCharacter> listContractCharacter)
        {
            await _dbContext.AddRangeAsync(listContractCharacter);
            return _dbContext.SaveChanges() > 0 ? true : false; 
        }

        //public async Task<int> CountCharactersInContractAsync(string contractId)
        //{
        //    if (string.IsNullOrEmpty(contractId))
        //        return 0;

        //    var totalCharacters = await _dbContext.ContractCharacters
        //        .Where(cc => cc.ContracId == contractId)
        //        .SumAsync(cc => cc.Quantity); // Tính tổng số lượng nhân vật

        //    return totalCharacters;
        //}
        //public async Task<RequestCharacter> GetContractCharacterById(string contractCharacterId)
        //{
        //    return await _dbContext.ContractCharacters.FirstOrDefaultAsync(sc => sc.ContractCharacterId.Equals(contractCharacterId));
        //}

        //public async Task AddCharacterInContract(RequestCharacter contractCharacter)
        //{
        //    _dbContext.ContractCharacters.Add(contractCharacter);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<bool> AddListCharacterInContract(List<RequestCharacter> contractCharacters)
        //{
        //    _dbContext.ContractCharacters.AddRange(contractCharacters);
        //    return await _dbContext.SaveChangesAsync() > 0;
        //}

        //public async Task UpdateChracterInContract(RequestCharacter contractCharacter)
        //{
        //    _dbContext.ContractCharacters.Update(contractCharacter);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteChracterInContract(RequestCharacter contractCharacter)
        //{
        //    _dbContext.ContractCharacters.Remove(contractCharacter);
        //    await _dbContext.SaveChangesAsync();
        //}
        public async Task<ContractCharacter> GetContractCharacterById(string id)
        {
            return await _dbContext.ContractCharacters
                .Include(c => c.Contract)
                    .ThenInclude(contract => contract.Request)
                .Include(c => c.Character)
                .FirstOrDefaultAsync(c => c.ContractCharacterId.Equals(id));
        }

    }
}
