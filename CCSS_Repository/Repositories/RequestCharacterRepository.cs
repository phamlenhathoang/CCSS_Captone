using CCSS_Repository.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId);
        Task<List<RequestCharacter>> GetListCharacterByRequest(string requestId);
        Task<bool> AddListRequestCharacter(List<RequestCharacter> requestCharacters);
        Task<bool> AddRequestCharacter(RequestCharacter requestCharacter);
        Task<bool> UpdateRequestCharacter(RequestCharacter requestCharacters);
        Task<bool> UpdateListRequestCharacter(List<RequestCharacter> requestCharacters);
        Task<bool> DeleteRequestCharacter(RequestCharacter requestCharacters);
        Task<RequestCharacter> GetRequestCharacterByRequestIdAndCharacterId(string requestId, string characterId);
        Task DeleteListCharacterInRequest(List<RequestCharacter> requestCharacterInRequest);
        Task<RequestCharacter> GetRequestCharacterCosplayerId(string requestId, string characterId, string cosplayerId);
        Task<List<RequestCharacter>> GetRequestCharacterByCosplayer(string cosplayerId);
        Task<List<RequestCharacter>> GetListRequestCharacterPending(string requestId);
        Task<List<RequestCharacter>> GetListRequestCharacterByCharacterId(string characterId);
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
            return await _context.RequestsCharacters.Include(rd => rd.RequestDates).Include(sc => sc.Character).ThenInclude(i => i.CharacterImages).ToListAsync();
        }

        public async Task<RequestCharacter> GetRequestCharacterById(string id)
        {
            return await _context.RequestsCharacters.Include(sc => sc.RequestDates).FirstOrDefaultAsync(sc => sc.RequestCharacterId.Equals(id));
        }

        public async Task<List<RequestCharacter>> GetRequestCharacterByCosplayer(string cosplayerId)
        {
            return await _context.RequestsCharacters.Include(s => s.RequestDates).Where(sc => sc.CosplayerId.Equals(cosplayerId)).ToListAsync();
        }

        public async Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId)
        {
            return await _context.RequestsCharacters.FirstOrDefaultAsync(sc => sc.RequestId.Equals(requestId) && sc.CharacterId.Equals(characterId));
        }

        public async Task<RequestCharacter> GetRequestCharacterCosplayerId(string requestId, string characterId, string cosplayerId)
        {
            return await _context.RequestsCharacters.FirstOrDefaultAsync(sc => sc.RequestId.Equals(requestId) && sc.CharacterId.Equals(characterId) && sc.CosplayerId.Equals(cosplayerId));
        }

        public async Task<List<RequestCharacter>> GetListCharacterByRequest(string requestId)
        {
            return await _context.RequestsCharacters.Where(sc => sc.RequestId.Equals(requestId)).ToListAsync();
        }

        public async Task<List<RequestCharacter>> GetListRequestCharacterPending(string requestId)
        {
            return await _context.RequestsCharacters.Where(sc => sc.RequestId.Equals(requestId) && sc.Status == RequestCharacterStatus.Pending).ToListAsync();
        }

        public async Task<bool> AddListRequestCharacter(List<RequestCharacter> requestCharacters)
        {
            _context.RequestsCharacters.AddRange(requestCharacters);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRequestCharacter(RequestCharacter requestCharacter)
        {
            _context.RequestsCharacters.Add(requestCharacter);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateListRequestCharacter(List<RequestCharacter> requestCharacters)
        {
            _context.RequestsCharacters.UpdateRange(requestCharacters);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRequestCharacter(RequestCharacter requestCharacters)
        {
            _context.RequestsCharacters.Update(requestCharacters);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRequestCharacter(RequestCharacter requestCharacters)
        {
            _context.RequestsCharacters.Remove(requestCharacters);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteListCharacterInRequest(List<RequestCharacter> requestCharacterInRequest)
        {
            _context.RequestsCharacters.RemoveRange(requestCharacterInRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<RequestCharacter> GetRequestCharacterByRequestIdAndCharacterId(string requestId, string characterId)
        {
            return await _context.RequestsCharacters.FirstOrDefaultAsync(r => r.CharacterId.Equals(characterId) && r.RequestId.Equals(requestId));
        }

        public async Task<List<RequestCharacter>> GetListRequestCharacterByCharacterId(string characterId)
        {
            return await _context.RequestsCharacters.Include(rq => rq.Request).Include(rq => rq.RequestDates).Where(rq =>
            !rq.Request.Status.Equals(RequestStatus.Cancel) && rq.CharacterId.Equals(characterId)).ToListAsync();


        }
    }
}
