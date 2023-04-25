using MediatR;
using Users.Application.Dtos.User.Responses;

namespace Users.Application.Features.Users.Queries.Login;
public record LoginQuery(
    string UserName,
    string Password) : IRequest<AuthenticationResponse>;
