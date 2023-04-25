using Common.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Extentions;
public static class DbContextExtensions
{
    public static IServiceCollection AddAppDbContext<TContext>(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder>? optionsAction = null,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        where TContext : AppDbContext
    {
        return services.AddDbContext<TContext>(optionsAction, contextLifetime, optionsLifetime);
    }
}
