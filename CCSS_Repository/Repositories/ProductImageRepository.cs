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
    public interface IProductImageRepository
    {
        Task<List<ProductImage>> GetAllImageProduct();
        Task<List<ProductImage>> GetListImageByProductId(string productId);
        Task<ProductImage> GetImageProductById(string productImageId);
        Task<bool> AddListImageProduct(List<ProductImage> productImages);
        Task Add(ProductImage productImage);
        Task UpdateProduct(ProductImage productImage);
        Task DeleteProduct(ProductImage productImage);
    }

    public class ProductImageRepository: IProductImageRepository
    {

        private readonly CCSSDbContext _context;

        public ProductImageRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductImage>> GetAllImageProduct()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<ProductImage> GetImageProductById(string productImageId)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(sc => sc.ProductImageId.Equals(productImageId));
        }
        public async Task<List<ProductImage>> GetListImageByProductId(string productId)
        {
            return await _context.ProductImages.Where(sc => sc.ProductId.Equals(productId)).ToListAsync();
        }

        public async Task<bool> AddListImageProduct(List<ProductImage> productImages)
        {
            _context.ProductImages.AddRange(productImages);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Add(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductImage productImage)
        {
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductImage productImage)
        {
            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
        }
    }
}
