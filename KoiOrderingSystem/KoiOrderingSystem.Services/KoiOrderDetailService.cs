using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services
{
    public class KoiOrderDetailService : IKoiOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public KoiOrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _orderDetailRepository.GetAllOrderDetails();
        }

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int orderDetailId)
        {
            return await _orderDetailRepository.GetOrderDetailById(orderDetailId);
        }

        public async Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public async Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            return await _orderDetailRepository.DeleteOrderDetail(orderDetailId);
        }
    }
}