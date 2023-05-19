using ApiGateway.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddOcelot("./Configuration", builder.Environment)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtSettings.Issuer,
        ValidateIssuer = true,

        ValidAudience = jwtSettings.Issuer,
        ValidateAudience = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        ValidateIssuerSigningKey = true,
        
        ValidateLifetime = true,
    };
});


builder.Services.AddCors(e =>
{
    e.AddPolicy("DefaultPolicy",e =>
    {
        e.WithOrigins(builder.Configuration.GetValue<string>("AllowOrigin"))
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("DefaultPolicy");
await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
