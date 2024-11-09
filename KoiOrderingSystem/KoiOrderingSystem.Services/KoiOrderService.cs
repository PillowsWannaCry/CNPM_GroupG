using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services
{
    public class KoiOrderService : IKoiOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public KoiOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _orderRepository.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await _orderRepository.DeleteOrder(orderId);
        }
    }
}