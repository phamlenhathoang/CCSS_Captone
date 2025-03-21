using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetCategory(string id);
        Task<Category> GetCategoryIncludeCharacter(string id);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CCSSDbContext _context;
        public CategoryRepository(CCSSDbContext cCSSDbContext)
        {
            _context = cCSSDbContext;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(string id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public Task<Category> GetCategoryIncludeCharacter(string id)
        {
            return _context.Categories.Include(c => c.Characters).ThenInclude(c => c.CharacterImages).FirstOrDefaultAsync(c => c.CategoryId.Equals(id));
        }
    }
}
