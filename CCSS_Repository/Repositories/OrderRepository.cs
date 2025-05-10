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
        Task<List<Order>> GetAllOrdersByAccountId(string accountId);
        Task<List<Product>> GetProductByOrderId(string id);
        Task<bool> UpdateProductQuantitiesAfterPayment(string orderId);
        Task<List<Product>> GetProductsByOrderId(string orderId);
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
        public async Task<List<Product>> GetProductsByOrderId(string orderId)
        {
            var products = await _dbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .Include(op => op.Product)
                .Select(op => op.Product)
                .ToListAsync();

            return products;
        }
        public async Task<List<Order>> GetAllOrdersByAccountId(string accountId)
        {
            return await _dbContext.Orders
                .Include(o => o.Payment)
                .Include(o => o.Account)
                .Include(o => o.OrderProducts)
                .ThenInclude(o => o.Product)
                .ThenInclude(o => o.ProductImages)
                .Where(o=>o.AccountId==accountId && o.OrderStatus == OrderStatus.Completed)
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

        public async Task<List<Product>> GetProductByOrderId(string id)
        {
            return await _dbContext.Products
                .Where(p => p.OrderProducts.Any(op => op.Order.OrderId == id))
                .ToListAsync();
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
        public async Task<bool> UpdateProductQuantitiesAfterPayment(string orderId)
        {
            // Lấy tất cả OrderProduct theo OrderId
            var orderProducts = await _dbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .Include(op => op.Product)
                .ToListAsync();

            if (orderProducts == null || !orderProducts.Any())
            {
                return false; // Không tìm thấy order hoặc không có sản phẩm
            }

            foreach (var orderProduct in orderProducts)
            {
                var product = orderProduct.Product;
                if (product != null && product.Quantity.HasValue)
                {
                    product.Quantity -= orderProduct.Quantity;

                    // Đảm bảo Quantity không âm
                    if (product.Quantity < 0)
                        product.Quantity = 0;
                }
            }

            await _dbContext.SaveChangesAsync();
            return true;
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