namespace AppleShop.Product.API.Installer;

public static class InstallerExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = typeof(Program).Assembly
            .ExportedTypes
            .Where(t => typeof(IInstaller).IsAssignableFrom(t)
                && !t.IsInterface
                && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

        installers.ForEach(installer =>
        {
            installer.InstallServices(services, configuration);
        });
    }
}