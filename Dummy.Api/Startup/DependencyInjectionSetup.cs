using Dummy.Application.Extensions;
using System.Reflection;

namespace Dummy.Api.Startup;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder builder) 
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddDummyApplication();

        return builder;
    }
}
