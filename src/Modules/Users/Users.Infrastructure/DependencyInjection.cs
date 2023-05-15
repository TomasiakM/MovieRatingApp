using Common.Infrastructure;
using Common.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Users;
using Users.Domain.Interfaces;
using Users.Infrastructure.Persistence;
using Users.Infrastructure.Services;
using Users.Infrastructure.Settings;

namespace Users.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var cookieSettings = new CookieSettings();
        configuration.GetSection(nameof(CookieSettings)).Bind(cookieSettings);

        services.AddCommonInfrastructure();
        services.AddModuleAuthorization()
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = cookieSettings.Name;
                options.ExpireTimeSpan = TimeSpan.FromDays(cookieSettings.ExpiryDays);

                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.HttpOnly = true;

                options.LoginPath = "/api/auth/login";
                options.LogoutPath = "/api/auth/logout";

                options.SlidingExpiration = true;
            });

        services.AddAppSwagger();

        services.AddAppDbContext<UserDbContext>();

        services.Configure<JwtSettings>(
            configuration.GetSection(nameof(JwtSettings)));


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IHashService, HashService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }

    public static async Task<IApplicationBuilder> AddInfrastructure(this IApplicationBuilder app)
    {
        await app.AddMigrationOnStartup<UserDbContext>();

        await using var scope = app.ApplicationServices.CreateAsyncScope();
        using var dbContext = scope.ServiceProvider.GetService<UserDbContext>();

        if (dbContext is null)
        {
            throw new NullReferenceException(nameof(UserDbContext));
        }

        var admin = await dbContext.Set<User>()
            .FirstOrDefaultAsync(e => e.UserName == CreateAdmin().UserName);

        if(admin is null)
        {
            dbContext.Add(CreateAdmin());
            await dbContext.SaveChangesAsync();
        }

        return app;
    }


    private static User CreateAdmin()
    {
        var adminPassword = new HashService().HashPassword("Password");
        var user = new User(
            "Admin",
            adminPassword,
            "admin@mail.com");

        user.AddRole(Role.AdminRoleId);

        return user;
    }
}
