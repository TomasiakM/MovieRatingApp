using MediatR;

namespace Movies.Application.Features.Genres.Commands.Create;
public record CreateGenreCommand(
    string Name) : IRequest;
