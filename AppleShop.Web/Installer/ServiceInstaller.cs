using AppleShop.Web.Domain.Services;
using AppleShop.Web.Extensions;
using AppleShop.Web.Services;

namespace AppleShop.Web.Installer;

public class ServiceInstaller : IInstaller
{
    private const int HandlerLifetime = 5;

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddHttpClient<IProductService, ProductService>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(HandlerLifetime))
            .AddPolicyHandlers("PolicyConfig", configuration);

        services.AddHttpClient<ICategoryService, CategoryService>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(HandlerLifetime))
            .AddPolicyHandlers("PolicyConfig", configuration);

        services.AddHttpClient<ICartService, CartService>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(HandlerLifetime))
            .AddPolicyHandlers("PolicyConfig", configuration);

        services.AddHttpClient<IOrderService, OrderService>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(HandlerLifetime))
            .AddPolicyHandlers("PolicyConfig", configuration);

        services.AddScoped<IPhotoService, PhotoService>();
    }
}