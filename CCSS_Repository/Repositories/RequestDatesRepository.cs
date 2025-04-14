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
    public interface IRequestDatesRepository
    {
        Task<List<RequestDate>> GetAllRequestDates();
        Task<RequestDate> GetRequestDateById(string id);
        Task<bool> AddListRequestDates(List<RequestDate> requestDate);
        Task<bool> UpdateListRequestDates(List<RequestDate> requestDate);
        Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId);
        Task DeleteAllRequestDateByRequestCharacterId(string requestCharacterId);
        Task UpdateRequestDate(RequestDate requestDate);
    }

    public class RequestDatesRepository: IRequestDatesRepository
    {
        private readonly CCSSDbContext _context;

        public RequestDatesRepository(CCSSDbContext context)
        {
            _context = context;
        }


        public async Task<List<RequestDate>> GetAllRequestDates()
        {
            return await _context.RequestDates.ToListAsync();
        }

        public async Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId)
        {
            return await _context.RequestDates.Include(rc => rc.RequestCharacter).Where(sc => sc.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
        }
        public async Task<RequestDate> GetRequestDateById(string id)
        {
            return await _context.RequestDates.FirstOrDefaultAsync(sc => sc.RequestDateId.Equals(id));  
        }
        public async Task<bool> AddListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.AddRange(requestDate);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateRequestDate(RequestDate requestDate)
        {
            _context.RequestDates.Update(requestDate);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.UpdateRange(requestDate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAllRequestDateByRequestCharacterId(string requestCharacterId)
        {
            var requestDate = await GetListRequestDateByRequestCharacterId(requestCharacterId);
            if (requestDate != null && requestDate.Any())
            {           
                _context.RequestDates.RemoveRange(requestDate);             
                await _context.SaveChangesAsync();
            }
        }
    }
}
