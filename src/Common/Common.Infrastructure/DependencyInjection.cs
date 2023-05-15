using Common.Application.Interfaces;
using Common.Domain.Interfaces;
using Common.Infrastructure.Persistance;
using Common.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IDateProvider, DateProvider>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }

    public static async Task AddMigrationOnStartup<TContext>(this IApplicationBuilder app)
        where TContext : AppDbContext
    {
        await using var scope = app.ApplicationServices.CreateAsyncScope();
        using var dbContext = scope.ServiceProvider.GetService<TContext>();

        if (dbContext is null)
        {
            throw new NullReferenceException(nameof(TContext));
        }

        await dbContext.Database.MigrateAsync();
    }
}
