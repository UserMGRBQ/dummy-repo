using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Specs.Drivers.Factories;

public class ServiceProviderFactory
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        var configuration = ConfigurationFactory.CreateConfiguration();

        services.AddSingleton(configuration);

        return services.BuildServiceProvider();
    }
}