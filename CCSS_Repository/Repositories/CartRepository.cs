using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
        Task<Cart> GetcartByAccount(string accountId);
        Task<bool> AddCart(Cart cart);
        Task DeleteCart(Cart cart);
        Task<bool> UpdateCart(Cart cart);
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
            return await _context.Carts.Include(p => p.CartProducts).ThenInclude(sc => sc.Product).FirstOrDefaultAsync(sc => sc.CartId.Equals(id));
        }

        public async Task<Cart> GetcartByAccount(string accountId)
        {
            return await _context.Carts.Include(p => p.CartProducts).ThenInclude(sc => sc.Product).FirstOrDefaultAsync(sc => sc.AccountId.Equals(accountId));
        }
        public async Task<bool> AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
             return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
