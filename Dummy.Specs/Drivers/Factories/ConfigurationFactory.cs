using Microsoft.Extensions.Configuration;

namespace Dummy.Specs.Drivers.Factories;

public class ConfigurationFactory
{
    public static IConfiguration CreateConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}