using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Dtos.User.Requests;
using Users.Application.Features.Users.Commands.Register;
using Users.Application.Features.Users.Commands.UpdatePassword;
using Users.Application.Features.Users.Queries.Login;
using Users.Application.Features.Users.Queries.Logout;
using Users.Application.Features.Users.Queries.RefreshToken;

namespace Users.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public AuthController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var loginResponse = await _mediatr.Send(query);

        return Ok(loginResponse);
    }

    [Authorize]
    [HttpPut("password")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
    {
        var command = _mapper.Map<UpdatePasswordCommand>(request);
        await _mediatr.Send(command);

        return Ok();
    }

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var query = new RefreshTokenQuery();
        var res = await _mediatr.Send(query);

        return Ok(res);
    }

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var query = new LogoutQuery();
        await _mediatr.Send(query);

        return Ok();
    }
}
