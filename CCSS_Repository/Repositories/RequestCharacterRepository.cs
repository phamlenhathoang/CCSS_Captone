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
    public interface IRequestCharacterRepository
    {
        Task<List<RequestCharacter>> GetAllRequestCharacter();
        Task<RequestCharacter> GetRequestCharacterById(string id);
        Task<List<RequestCharacter>> GetListCharacterByRequest(string requestId);
        Task<bool> AddListRequestCharacter(List<RequestCharacter> requestCharacters);
        Task<bool> UpdateListRequestCharacter(List<RequestCharacter> requestCharacters);
        Task DeleteListRequestCharacter(List<RequestCharacter> requestCharacters);
    }


    public class RequestCharacterRepository: IRequestCharacterRepository
    {
        private readonly CCSSDbContext _context;

        public RequestCharacterRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestCharacter>> GetAllRequestCharacter()
        {
            return await _context.RequestsCharacters.ToListAsync();
        }

        public async Task<RequestCharacter> GetRequestCharacterById(string id)
        {
            return await _context.RequestsCharacters.FirstOrDefaultAsync(sc => sc.RequestCharacterId.Equals(id));
        }

        public async Task<List<RequestCharacter>> GetListCharacterByRequest(string requestId)
        {
            return await _context.RequestsCharacters.Where(sc => sc.RequestId.Equals(requestId)).ToListAsync();
        }

        public async Task<bool> AddListRequestCharacter(List<RequestCharacter> requestCharacters)
        {
            _context.RequestsCharacters.AddRange(requestCharacters);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateListRequestCharacter(List<RequestCharacter> requestCharacters)
        {
            _context.RequestsCharacters.UpdateRange(requestCharacters);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteListRequestCharacter(List<RequestCharacter> requestCharacters)
        {
            _context.RequestsCharacters.RemoveRange(requestCharacters);
            await _context.SaveChangesAsync();
        }
    }
}
