using MediatR;

namespace Movies.Application.Features.Movies.Commands.Delete;
public record DeleteMovieCommand(
    Guid MovieId) : IRequest;
