using CCSS_Repository.Entities;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct(string searchterm);
        Task<Product> GetProductById(string productId);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }

    public class ProductRepository: IProductRepository
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
                return await _context.Products.Where(sc => sc.IsActive == true).ToListAsync();
            }
            else
            {
                return await _context.Products.Where(sc =>sc.IsActive == true && sc.ProductName.Contains(searchterm) ).OrderByDescending(p => p.CreateDate).ToListAsync();
            }
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _context.Products.FirstOrDefaultAsync(sc => sc.ProductId.Equals(productId));
        }

        public async Task<bool> AddProduct(Product product)
        {
            _context.Products.Add(product);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
