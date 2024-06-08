using Dummy.Core.Interfaces.Repository.Commands;
using Dummy.Core.Interfaces.Repository.Queries;
using Dummy.Persistence.Contexts;
using Dummy.Persistence.Repositories.Commands;
using Dummy.Persistence.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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