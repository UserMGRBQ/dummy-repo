using Dummy.Api.Startup;

namespace Dummy.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        /// Segregation of responsability can be found in 
        /// AppConfiguration class & DependencyInjectionSetup class
        WebApplication
            .CreateBuilder(args)
            .AddDependencies()
            .Build()
            .ConfigureApp()
            .Run();
    }
}