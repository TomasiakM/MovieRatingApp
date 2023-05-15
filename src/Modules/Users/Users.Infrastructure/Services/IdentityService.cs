using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Users.Application.Dtos.User.Responses;
using Users.Application.Interfaces;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Users;
using Users.Domain.Interfaces;

namespace Users.Infrastructure.Services;
internal class IdentityService : IIdentityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IHashService _hashService;
    private readonly IHttpContextAccessor _contextAccessor;

    public IdentityService(IUnitOfWork unitOfWork, ITokenService tokenService, IHashService hashService, IHttpContextAccessor contextAccessor)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _hashService = hashService;
        _contextAccessor = contextAccessor;
    }

    public async Task<AuthenticationResponse> Login(string userName, string password, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.FindAsync(e => e.UserName == userName);

        if (user is null || !_hashService.VerifyPassword(password, user.Password))
        {
            throw new UnauthorizedException();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = true,
        };


        await _contextAccessor.HttpContext!.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return GenerateAuthenticationResponse(user);
    }

    

    public async Task Register(string userName, string password, string email, CancellationToken cancellationToken = default)
    {
        var hashedPassword = _hashService.HashPassword(password);

        var user = new User(userName, hashedPassword, email);
        _unitOfWork.Users.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public AuthenticationResponse GenerateAuthenticationResponse(User user)
    {
        var token = _tokenService.GenerateAccessToken(user);

        var role = Role.UserRole.Name;
        if (user.RoleIds.Any(e => e.Value == Role.AdminRoleId))
        {
            role = Role.AdminRole.Name;
        }

        return new(
            user.UserName,
            user.Image,
            role,
            token);
    }

    public async Task Logout()
    {
        await _contextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
