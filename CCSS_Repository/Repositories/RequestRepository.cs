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
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllRequest();
        Task<Request> GetRequestById(string id);
        Task<bool> AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task DeleteRequest(Request request);
        Task<Request> GetRequestIncludeRequestCharacter(string requestId);
        Task<Request> GetRequestByIdInclude(string id);
        Task<List<Request>> GetAllRequestByAccountId(string accountId);
    }

    public class RequestRepository: IRequestRepository
    {
        private readonly CCSSDbContext _context;

        public RequestRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAllRequest()
        {
            return await _context.Requests.Include(sc => sc.RequestCharacters).ToListAsync();
        }

        public async Task<List<Request>> GetAllRequestByAccountId(string accountId)
        {
            return await _context.Requests.Include(c => c.RequestCharacters).Where(sc => sc.AccountId.Equals(accountId)).ToListAsync();
        }
        public async Task<Request> GetRequestById(string id)
        {
            return await _context.Requests.Include(r => r.RequestCharacters).FirstOrDefaultAsync(sc => sc.RequestId.Equals(id));  
        }

        public async Task<bool> AddRequest( Request request)
        {
            _context.Requests.Add(request);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequest(Request request)
        {
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }

        

        public async Task<Request> GetRequestByIdInclude(string id)
        {
            return await _context.Requests.Include(a => a.Account).Include(c => c.Contract)
                                          .Include(s => s.Service)
                                          .Include(rc => rc.RequestCharacters)
                                          .FirstOrDefaultAsync(sc => sc.RequestId.Equals(id));
        }

        public async Task<Request> GetRequestIncludeRequestCharacter(string requestId)
        {
            return await _context.Requests.Include(rc => rc.RequestCharacters).FirstOrDefaultAsync(r => r.RequestId.Equals(requestId));
        }
    }
}
