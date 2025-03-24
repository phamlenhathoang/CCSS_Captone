using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCSS_Repository.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(string id);
        Task<bool> AddOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(string id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly CCSSDbContext _dbContext;

        public OrderRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Lấy tất cả các đơn hàng
        /// </summary>
        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbContext.Orders
                .Include(o => o.Payment)
                .Include(o => o.Account)
                .Include(o => o.OrderProducts)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy đơn hàng theo ID
        /// </summary>
        public async Task<Order> GetOrderById(string id)
        {
            return await _dbContext.Orders
                .Include(o => o.Payment)
                .Include(o => o.Account)
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        /// <summary>
        /// Thêm mới một đơn hàng
        /// </summary>
        public async Task<bool> AddOrder(Order order)
        {
            if (order == null)
                return false;

            await _dbContext.Orders.AddAsync(order);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Cập nhật đơn hàng
        /// </summary>
        public async Task<bool> UpdateOrder(Order order)
        {
            var existingOrder = await _dbContext.Orders.FindAsync(order.OrderId);
            if (existingOrder == null)
                return false;

            _dbContext.Entry(existingOrder).CurrentValues.SetValues(order);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Xóa đơn hàng theo ID
        /// </summary>
        public async Task<bool> DeleteOrder(string id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
                return false;

            // Xóa tất cả OrderProduct liên quan trước
            var orderProducts = _dbContext.OrderProducts.Where(op => op.OrderId == id);
            _dbContext.OrderProducts.RemoveRange(orderProducts);

            // Xóa Order
            _dbContext.Orders.Remove(order);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

    }
}