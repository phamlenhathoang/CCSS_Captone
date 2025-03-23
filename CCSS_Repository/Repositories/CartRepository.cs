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
    public interface ICartRepository
    {
        Task<Cart> GetCartById(string id);
        Task AddCart(Cart cart);
        Task DeleteCart(Cart cart);
    }

    public class CartRepository: ICartRepository
    {
        private readonly CCSSDbContext _context;

        public CartRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartById(string id)
        {
            return await _context.Carts.FirstOrDefaultAsync(sc => sc.CartId.Equals(id));
        }

        public async Task AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
