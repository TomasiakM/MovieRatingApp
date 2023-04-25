using MediatR;

namespace Movies.Application.Features.Genres.Commands.Update;
public record UpdateGenreCommand(
    Guid GenreId,
    string Name) : IRequest;
