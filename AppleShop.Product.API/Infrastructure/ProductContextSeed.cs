using AppleShop.Product.API.Enums;
using AppleShop.Product.API.Models;

namespace AppleShop.Product.API.Infrastructure;

public class ProductContextSeed
{
    public async Task SeedAsync(ProductDbContext context)
    {
        if (!context.Categories.Any())
        {
            await context.Categories.AddRangeAsync(GetPreconfiguredCategories());
            await context.SaveChangesAsync();
        }

        if (!context.Products.Any() && context.Categories.Any())
        {
            var categories = context.Categories.ToList();

            await context.Products.AddRangeAsync(GetPreconfiguredProducts(categories));
            await context.SaveChangesAsync();
        }
    }

    private IEnumerable<Category> GetPreconfiguredCategories()
    {
        return new List<Category>()
        {
            new()
            {
                Name = "iPhone"
            },
            new()
            {
                Name = "Apple Watch"
            },
            new()
            {
                Name = "iPad"
            },
            new()
            {
                Name = "Mac"
            }
        };
    }

    private IEnumerable<Models.Product> GetPreconfiguredProducts(List<Category> categories)
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
                Category = categories.Single(c => c.Name == "iPhone")
            },
            new()
            {
                Name = "Apple Watch Ultra",
                Series = "49mm Titanium Case",
                Description = string.Empty,
                Color = ColorType.Black,
                Memory = 8,
                AvailableStock = 5,
                PictureUri = string.Empty,
                Price = 33.329,
                Category = categories.Single(c => c.Name == "Apple Watch")
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
                Category = categories.Single(c => c.Name == "iPad")
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
                Category = categories.Single(c => c.Name == "Mac")
            }
        };
    }
}