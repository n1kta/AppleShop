using AppleShop.Product.API.Enums;

namespace AppleShop.Product.API.Infrastructure;

public class ProductContextSeed
{
    public async Task SeedAsync(ProductDbContext context)
    {
        if (!context.Products.Any())
        {
            await context.Products.AddRangeAsync(GetPreconfiguredProducts());
            await context.SaveChangesAsync();
        }
    }

    private IEnumerable<Models.Product> GetPreconfiguredProducts()
    {
        return new List<Models.Product>()
        {
            new()
            {
                Name = "Apple iPhone 14 Pro",
                Description = "Відкрийте для себе чарівне майбутнє смартфонів, купивши Apple iPhone 14 Pro Max. Ім'я говорить саме за себе. Максимум можливостей та максимальна продуктивність у 6.7 дюймовому корпусі. Давайте читати!",
                Color = ColorType.Black,
                Memory = 512,
                AvailableStock = 10,
                PictureUri = string.Empty,
                Price = 64.602,
                Category = new()
                {
                    Name = "iPhone"
                }
            },
            new()
            {
                Name = "Apple Watch Ultra 49mm Titanium Case",
                Description = string.Empty,
                Color = ColorType.Black,
                Memory = 8,
                AvailableStock = 5,
                PictureUri = string.Empty,
                Price = 33.329,
                Category = new()
                {
                    Name = "Apple Watch"
                }
            },
            new()
            {
                Name = "Apple iPad 10.9",
                Description = string.Empty,
                Color = ColorType.Black,
                Memory = 64,
                AvailableStock = 9,
                PictureUri = string.Empty,
                Price = 18.818,
                Category = new()
                {
                    Name = "iPad"
                }
            },
            new()
            {
                Name = "Apple MacBook Pro 16",
                Description = string.Empty,
                Color = ColorType.Black,
                Memory = 512,
                AvailableStock = 9,
                PictureUri = string.Empty,
                Price = 99.677,
                Category = new()
                {
                    Name = "Mac"
                }
            }
        };
    }
}