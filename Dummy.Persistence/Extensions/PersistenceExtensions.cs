using Dummy.Core.Interfaces.Repository.Commands;
using Dummy.Core.Interfaces.Repository.Queries;
using Microsoft.Extensions.DependencyInjection;
using Dummy.Persistence.Repositories.Commands;
using Dummy.Persistence.Repositories.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Dummy.Persistence.Contexts;

namespace Dummy.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDummyPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DummyCommandContext>((context, options) =>
            options.UseSqlServer(context.GetRequiredService<IConfiguration>().GetConnectionString("DummyCommandConnection")));

        services.AddDbContext<DummyQueryContext>((context, options) =>
            options.UseSqlServer(context.GetRequiredService<IConfiguration>().GetConnectionString("DummyQueryConnection")));

        services.AddScoped<ICommandUserRepository, CommandUserRepository>();
        services.AddScoped<IQueryUserRepository, QueryUserRepository>();

        return services;
    }
}