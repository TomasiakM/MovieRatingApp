using Common.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Comments.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service) 
    {
        service.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        service.AddMapster();

        return service;
    }
}
