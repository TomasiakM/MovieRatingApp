using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Application.Features.Movies.Commands.Delete;
internal class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movieId = new MovieId(request.MovieId);
        var movie = await _unitOfWork.Movies.GetAsync(movieId);

        if (movie is null)
        {
            throw new NotFoundException();
        }

        _unitOfWork.Movies.Delete(movie);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
