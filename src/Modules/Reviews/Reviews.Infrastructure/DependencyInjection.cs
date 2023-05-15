using Common.Infrastructure;
using Common.Infrastructure.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Reviews.Application.Interfaces;
using Reviews.Infrastructure.Persistence;

namespace Reviews.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommonInfrastructure();
        services.AddModuleAuthorization();

        services.AddAppDbContext<ReviewDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static async Task AddInfrastructure(this IApplicationBuilder app)
    {
        await app.AddMigrationOnStartup<ReviewDbContext>();
    }
}
