using MediatR;

namespace Users.Application.Features.Users.Commands.UpdatePassword;
public record UpdatePasswordCommand(
    string Password,
    string NewPassword) : IRequest;
