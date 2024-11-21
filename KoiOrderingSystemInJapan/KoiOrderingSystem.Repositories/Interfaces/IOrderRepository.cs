using KoiOrderingSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int orderId);
        Task<bool> AddOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int orderId);
        Task<bool> DeleteOrder(Order order);
    }
}
