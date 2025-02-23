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
        Task<ContractCharacter> GetContractCharacterById(string contractCharacterId);
        Task AddCharacterInContract(ContractCharacter contractCharacter);
        Task<bool> AddListCharacterInContract(List<ContractCharacter> contractCharacters);
        Task UpdateChracterInContract(ContractCharacter contractCharacter);
        Task DeleteChracterInContract(ContractCharacter contractCharacter);
        Task<int> CountCharactersInContractAsync(string contractId);
    }
    public class ContractCharacterRepository: IContractCharacterRepository
    {
        private readonly CCSSDbContext _dbContext;

        public ContractCharacterRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountCharactersInContractAsync(string contractId)
        {
            if (string.IsNullOrEmpty(contractId))
                return 0;

            var totalCharacters = await _dbContext.ContractCharacters
                .Where(cc => cc.ContracId == contractId)
                .SumAsync(cc => cc.Quantity); // Tính tổng số lượng nhân vật

            return totalCharacters;
        }
        public async Task<ContractCharacter> GetContractCharacterById(string contractCharacterId)
        {
            return await _dbContext.ContractCharacters.FirstOrDefaultAsync(sc => sc.ContractCharacterId.Equals(contractCharacterId));
        }

        public async Task AddCharacterInContract(ContractCharacter contractCharacter)
        {
            _dbContext.ContractCharacters.Add(contractCharacter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AddListCharacterInContract(List<ContractCharacter> contractCharacters)
        {
            _dbContext.ContractCharacters.AddRange(contractCharacters);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task UpdateChracterInContract(ContractCharacter contractCharacter)
        {
            _dbContext.ContractCharacters.Update(contractCharacter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteChracterInContract(ContractCharacter contractCharacter)
        {
            _dbContext.ContractCharacters.Remove(contractCharacter);
            await _dbContext.SaveChangesAsync();
        }
    }
}
