using Common.Application.Extensions;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Reviews.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMapster();
        return services;
    }
}
