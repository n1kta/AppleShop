using AppleShop.Basket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Basket.API.Infrastructure
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<CartHeader> CartHeaders { get; set; }

        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
