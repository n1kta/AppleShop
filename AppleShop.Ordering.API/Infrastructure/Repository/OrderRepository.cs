using AppleShop.Ordering.API.DTOs;
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

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            await using var _context = new OrderingDbContext(_contextOptions);

            var order = await _context.Orders.ToListAsync();

            var result = order.Select(o => new OrderDto
            {
                FullName = o.FirstName + " " + o.LastName,
                Email = o.Email,
                Phone = o.Phone,
                CardNumber = o.CardNumber,
                CartTotalItems = o.CartTotalItems,
                OrderTotal = o.OrderTotal
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<OrderStatisticDto>> GetStatistic()
        {
            await using var _context = new OrderingDbContext(_contextOptions);

            var grouppedOrder = await _context.Orders
                .GroupBy(
                    p => new { p.FirstName, p.LastName},
                    p => p.OrderTotal,
                    (key, g) => new OrderStatisticDto { FullName = key.FirstName + " " + key.LastName, Amount = (int) g.Sum() })
                .ToListAsync();

            return grouppedOrder;
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
