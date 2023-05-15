using MediatR;
using Users.Application.Dtos.User.Responses;

namespace Users.Application.Features.Users.Queries.RefreshToken;
public record RefreshTokenQuery() : IRequest<AuthenticationResponse>;