using AppleShop.Ordering.API.DTOs;
using AppleShop.Ordering.API.Models;

namespace AppleShop.Ordering.API.Infrastructure.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAll();

        Task<bool> AddOrder(Order order);

        Task<bool> UpdateOrderPaymentStatus(int orderId, bool isPaid);
    }   
}
