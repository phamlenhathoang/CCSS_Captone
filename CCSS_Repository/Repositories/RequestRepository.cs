using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public class RequestRepository
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


    }
}
