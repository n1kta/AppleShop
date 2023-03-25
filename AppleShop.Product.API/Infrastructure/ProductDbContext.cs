using AppleShop.Product.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }

        public DbSet<Models.Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
