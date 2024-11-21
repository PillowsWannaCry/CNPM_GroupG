using KoiOrderingSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services.Interfaces
{
    public interface IKoiOrderService
    {
        
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<bool> AddOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
