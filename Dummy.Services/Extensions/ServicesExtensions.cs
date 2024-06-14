using Dummy.Core.Interfaces.RabbitMqServices;
using Dummy.Services.RabbitMqServices;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Services.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddDummyServices(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 1572, "/", h =>
                {
                    h.Username("admin");
                    h.Password("admin");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<IUserQueue, UserQueue>();

        return services;
    }
}