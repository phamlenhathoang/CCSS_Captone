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
    public interface ICartProductRepository
    {
        Task<List<CartProduct>> GetAllCartProduct();
        Task<CartProduct> GetCartProductById(string id);
        Task<CartProduct> GetCartProduct(string productId, string cartId);
        Task<List<CartProduct>> GetListProductInCart(string cartId);
        Task<bool> AddCartProduct(CartProduct cartProduct);
        Task UpdateCartProduct(CartProduct cartProduct);       
        Task<bool> DeleteCartProduct(CartProduct cartProduct);
    }

    public class CartProductRepository: ICartProductRepository
    {
        private readonly CCSSDbContext _context;

        public CartProductRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartProduct>> GetAllCartProduct()
        {
            return await _context.CartProducts.ToListAsync();
        }

        public async Task<CartProduct> GetCartProductById(string id)
        {
            return await _context.CartProducts.FirstOrDefaultAsync(sc => sc.CartProductId.Equals(id));
        }

        public async Task<CartProduct> GetCartProduct(string productId, string cartId)
        {
            return await _context.CartProducts.Include(sc => sc.Cart).Include(p => p.Product).FirstOrDefaultAsync(sc => sc.ProductId.Equals(productId) && sc.CartId.Equals(cartId));
        }

        public async Task<List<CartProduct>> GetListProductInCart(string cartId)
        {
            return await _context.CartProducts.Where(sc => sc.CartId.Equals(cartId)).ToListAsync();
        }

        public async Task<bool> AddCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.AddRange(cartProduct);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.Update(cartProduct);
            await _context.SaveChangesAsync();
        }       

        public async Task<bool> DeleteCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.RemoveRange(cartProduct);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
