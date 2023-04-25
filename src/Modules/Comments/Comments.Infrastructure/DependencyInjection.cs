using Comments.Application.Interfaces;
using Comments.Infrastructure.Persistence;
using Common.Infrastructure;
using Common.Infrastructure.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Comments.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommonInfrastructure();

        services.AddAppDbContext<CommentDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static async Task<IApplicationBuilder> AddInfrastructure(this IApplicationBuilder app)
    {
        await app.AddMigrationOnStartup<CommentDbContext>();

        return app;
    }
}
