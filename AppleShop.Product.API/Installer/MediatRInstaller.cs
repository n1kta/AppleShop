using MediatR;
using System.Reflection;

namespace AppleShop.Product.API.Installer
{
    public sealed class MediatRInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
