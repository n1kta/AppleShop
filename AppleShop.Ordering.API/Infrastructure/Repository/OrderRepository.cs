using AppleShop.Ordering.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Ordering.API.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<OrderingDbContext> _contextOptions;

        public OrderRepository(DbContextOptions<OrderingDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public async Task<bool> AddOrder(Order order)
        {
            await using var _context = new OrderingDbContext(_contextOptions);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderPaymentStatus(int orderId, bool isPaid)
        {
            await using var _context = new OrderingDbContext(_contextOptions);
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null)
                return false;
            
            order.PaymentStatus = isPaid;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
