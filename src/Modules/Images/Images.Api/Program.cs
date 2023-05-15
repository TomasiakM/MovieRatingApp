using Images.Api.Services;
using Common.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddHttpClient();

builder.Services.AddModuleAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
