using KoiOrderingSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services.Interfaces
{
    public interface IKoiOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> AddOrderDetailAsync(OrderDetail orderDetail);
        Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
    }
}