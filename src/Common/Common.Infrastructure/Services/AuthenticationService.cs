using Common.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Common.Infrastructure.Services;
internal class AuthenticationService : IAuthenticationService
{
    private readonly IHttpContextAccessor _contextAccessor;
    private string? _userId => _contextAccessor.HttpContext!.User.Claims
        .FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value;

    public bool IsAuthorized => _userId != null;

    public AuthenticationService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Guid GetUserId() => Guid.Parse(_userId!);
}
