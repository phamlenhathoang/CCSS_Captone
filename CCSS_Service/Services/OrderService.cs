using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    // Định nghĩa interface cho OrderService
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrders(); 
        Task<OrderResponse> GetOrderById(string id); 
        Task<string> CreateOrder(OrderRequest orderRequest);
        Task<bool> UpdateOrder(string id, OrderRequest orderRequest); 
        Task<bool> DeleteOrder(string id);
        Task<List<OrderResponse>> GetAllOrdersByAccountId(string accountId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository; 
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository; 
            _mapper = mapper; 
            _productRepository = productRepository;
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return _mapper.Map<List<OrderResponse>>(orders); 
        }
        public async Task<List<OrderResponse>> GetAllOrdersByAccountId(string accountId)
        {
            var orders = await _orderRepository.GetAllOrdersByAccountId(accountId);
            return _mapper.Map<List<OrderResponse>>(orders); 
        }

        public async Task<OrderResponse> GetOrderById(string id)
        {
            var order = await _orderRepository.GetOrderById(id);
            return _mapper.Map<OrderResponse>(order); 
        }

        public async Task<string> CreateOrder(OrderRequest orderRequest)
        {
           
            if (orderRequest == null || string.IsNullOrEmpty(orderRequest.AccountId))
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            
            var order = _mapper.Map<Order>(orderRequest);
            order.OrderId = Guid.NewGuid().ToString();
            order.OrderStatus = OrderStatus.Pending;
            order.OrderDate = DateTime.Now;

            
            order.OrderProducts = new List<OrderProduct>();

            foreach (var op in orderRequest.OrderProducts)
            {
                // Lấy giá sản phẩm từ ProductRepository
                var product = await _productRepository.GetProductById(op.ProductId);
                if (product == null) return "Không tìm thấy sản phẩm "+ product.ProductName + "!!!";
                if (product.Quantity < op.Quantity)
                    return "Số lượng sản phẩm "+ product.ProductName + " trong kho không đủ!!!";
                var orderProduct = new OrderProduct
                {
                    OrderProductId = Guid.NewGuid().ToString(),
                    OrderId = order.OrderId,
                    ProductId = op.ProductId,
                    Price = product.Price ?? 0.0, 
                    Quantity = op.Quantity,
                    CreateDate = DateTime.UtcNow
                };

                order.OrderProducts.Add(orderProduct);
            }

           
            order.TotalPrice = order.OrderProducts.Sum(op => op.Price * op.Quantity);

            var result = await _orderRepository.AddOrder(order);
            if (!result) return "Tạo Order thất bại!!!";
            return order.OrderId;
        }


        public async Task<bool> UpdateOrder(string id, OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.OrderId = id;
            return await _orderRepository.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrder(string id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
    }
}
