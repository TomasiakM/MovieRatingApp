using Common.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Users.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddAppliciation(this IServiceCollection services)
    {
        services.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMapster();

        return services;
    }
}
