using MediatR;

namespace Movies.Application.Features.Genres.Commands.Delete;
public record DeleteGenreCommand(
    Guid GenreId) : IRequest;
