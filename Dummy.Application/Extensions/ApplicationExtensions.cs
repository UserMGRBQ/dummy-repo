using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dummy.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddDummyApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}