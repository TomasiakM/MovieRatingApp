using MediatR;

namespace Movies.Application.Features.Movies.Commands.Update;
public record UpdateMovieCommand(
    Guid MovieId,
    string Title,
    string Description,
    string Image,
    string Premiere,
    string GenreId) : IRequest;
