namespace AppleShop.Product.API.Installer;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}