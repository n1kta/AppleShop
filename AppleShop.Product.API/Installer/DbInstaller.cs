using AppleShop.Product.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Installer;

public sealed class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
    }
}