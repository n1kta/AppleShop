using AppleShop.Ordering.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Ordering.API.Infrastructure
{
    public class OrderingDbContext : DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLineItem> LineItems { get; set; }
    }
}
