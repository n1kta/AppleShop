using AppleShop.Web.Extensions;
using AppleShop.Web.Services;

namespace AppleShop.Web.Installer;

public class ServiceInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddHttpClient<IProductService, ProductService>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandlers("PolicyConfig", configuration);
    }
}