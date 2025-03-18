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
        Task AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task DeleteRequest(Request request);
        Task<Request> GetRequestIncludeRequestCharacter(string requestId);
        Task<Request> GetRequestByIdInclude(string id);
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
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> GetRequestById(string id)
        {
            return await _context.Requests.FirstOrDefaultAsync(sc => sc.RequestId.Equals(id));  
        }

        public async Task AddRequest( Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
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
            return await _context.Requests.Include(a => a.Account)
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
