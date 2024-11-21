using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;


namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail?> GetOrderDetailById(int orderDetailId);
        Task<bool> AddOrderDetail(OrderDetail orderDetail);
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetail(int orderDetailId);
        Task<bool> DeleteOrderDetail(OrderDetail orderDetail);
    }
}
