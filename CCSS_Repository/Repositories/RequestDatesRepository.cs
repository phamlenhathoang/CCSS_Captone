using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IRequestDatesRepository
    {
        Task<List<RequestDate>> GetAllRequestDates();
        Task<RequestDate> GetRequestDateById(string id);
        Task<bool> AddListRequestDates(List<RequestDate> requestDate);
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
        public async Task<RequestDate> GetRequestDateById(string id)
        {
            return await _context.RequestDates.FirstOrDefaultAsync(sc => sc.RequestDateId.Equals(id));  
        }
        public async Task<bool> AddListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.AddRange(requestDate);
           return await _context.SaveChangesAsync() > 0;
        }
    }
}
