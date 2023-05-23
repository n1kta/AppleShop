using AppleShop.Ordering.API.Models;

namespace AppleShop.Ordering.API.Infrastructure.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);

        Task<bool> UpdateOrderPaymentStatus(int orderId, bool isPaid);
    }   
}
