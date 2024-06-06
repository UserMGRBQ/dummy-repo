using Dummy.Core.Interfaces.Repository;
using Dummy.Persistence.Contexts;
using Dummy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDummyPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DummyContext>((context, options) => 
        {
            options.UseSqlServer(context.GetRequiredService<IConfiguration>().GetConnectionString("DummyConnection"));
        });

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}