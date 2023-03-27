namespace AppleShop.Web.Installer;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}