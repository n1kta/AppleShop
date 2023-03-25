namespace AppleShop.Product.API.Infrastructure;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ProductDbContext>();

                    new ProductContextSeed().SeedAsync(context).Wait();
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
        return webApp;
    }
}