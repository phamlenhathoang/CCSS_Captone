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
        Task<bool> AddRequestDate(RequestDate requestDate);
        Task<bool> UpdateListRequestDates(List<RequestDate> requestDate);
        Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId);    
        Task<bool> UpdateRequestDate(RequestDate requestDate);
        Task<bool> DeleteListRequestDateByRequestCharacterId(string requestCharacterId);
        Task<List<RequestDate>> GetListRequestDateByRequestCharacter(string requestCharacterId);
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

        public async Task<List<RequestDate>> GetListRequestDateByRequestCharacter(string requestCharacterId)
        {
            return await _context.RequestDates.Where(sc => sc.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
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

        public async Task<bool> UpdateRequestDate(RequestDate requestDate)
        {
            _context.RequestDates.Update(requestDate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.UpdateRange(requestDate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteListRequestDateByRequestCharacterId(string requestCharacterId)
        {
            try
            {
                List<RequestDate> requestDates = await _context.RequestDates.Where(rd => rd.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
                if (requestDates != null)
                {
                    throw new Exception("RequestCharacterId does not exist");
                }

                _context.RemoveRange(requestDates);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddRequestDate(RequestDate requestDate)
        {
            await _context.RequestDates.AddAsync(requestDate);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
