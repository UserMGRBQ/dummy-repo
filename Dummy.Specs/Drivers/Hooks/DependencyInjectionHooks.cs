using Dummy.Specs.Drivers.Factories;

namespace Dummy.Specs.Drivers.Hooks;

[Binding]
public class DependencyInjectionHooks
{
    public static IServiceProvider ServiceProvider { get; set; }

    [BeforeTestRun]
    public static void RegisterServices()
    {
        ServiceProvider = ServiceProviderFactory.CreateServiceProvider();
    }
}