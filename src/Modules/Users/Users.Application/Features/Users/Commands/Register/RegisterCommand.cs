using MediatR;

namespace Users.Application.Features.Users.Commands.Register;
public record RegisterCommand(
    string UserName,
    string Password,
    string Email) : IRequest;
