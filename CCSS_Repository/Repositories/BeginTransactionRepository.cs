using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface IBeginTransactionRepository
    {
        Task<IDbContextTransaction> BeginTransaction();
    }

    public class BeginTransactionRepository: IBeginTransactionRepository
    {
        private readonly CCSSDbContext _context;

        public BeginTransactionRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
