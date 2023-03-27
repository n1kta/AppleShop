namespace AppleShop.Web.Installer;

public class OptionsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions()
            .Configure<AppSettings>(configuration)
            .AddSession()
            .AddDistributedMemoryCache();
    }
}