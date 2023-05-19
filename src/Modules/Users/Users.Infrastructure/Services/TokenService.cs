using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Users;
using Users.Domain.Interfaces;
using Users.Infrastructure.Settings;

namespace Users.Infrastructure.Services;
internal sealed class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(IOptions<JwtSettings> jwtSettingOption)
    {
        _jwtSettings = jwtSettingOption.Value;
    }

    public string GenerateAccessToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, Role.UserRole.Name),
        };

        if(user.IsAdmin())
        {
            claims.Add(new Claim(ClaimTypes.Role, Role.AdminRole.Name));
        }


        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Issuer,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
