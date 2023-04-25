using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Dtos.User.Requests;
using Users.Application.Features.Users.Commands.Register;
using Users.Application.Features.Users.Commands.UpdatePassword;
using Users.Application.Features.Users.Queries.Login;

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

    [HttpPut("password")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
    {
        var command = _mapper.Map<UpdatePasswordCommand>(request);
        await _mediatr.Send(command);

        return Ok();
    }
}
