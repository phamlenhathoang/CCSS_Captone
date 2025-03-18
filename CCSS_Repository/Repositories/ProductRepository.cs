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
    public class ProductRepository
    {
        private readonly CCSSDbContext _context;

        public ProductRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProduct(string searchterm)
        {
            if (string.IsNullOrWhiteSpace(searchterm))
            {
                return await _context.Products.ToListAsync();
            }
            else
            {
                return await _context.Products.Where(sc => sc.ProductName.Contains(searchterm)).OrderByDescending(p => p.CreateDate).ToListAsync();
            }
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _context.Products.FirstOrDefaultAsync(sc => sc.ProductId.Equals(productId));
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
