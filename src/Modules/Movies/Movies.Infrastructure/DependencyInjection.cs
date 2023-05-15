using Common.Infrastructure;
using Common.Infrastructure.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Interfaces;
using Movies.Infrastructure.Persistence;

namespace Movies.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommonInfrastructure();
        services.AddModuleAuthorization();

        services.AddAppSwagger();

        services.AddAppDbContext<MovieDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static async Task<IApplicationBuilder> AddInfrastructure(this IApplicationBuilder app)
    {
        await app.AddMigrationOnStartup<MovieDbContext>();

        return app;
    }
}
