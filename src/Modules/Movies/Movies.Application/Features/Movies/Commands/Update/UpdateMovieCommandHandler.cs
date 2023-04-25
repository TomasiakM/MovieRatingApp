using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Genres.ValueObjects;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Application.Features.Movies.Commands.Update;
internal class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieId = new MovieId(request.MovieId);
        var movie = await _unitOfWork.Movies.GetAsync(movieId);

        if (movie is null)
        {
            throw new NotFoundException();
        }

        movie.Update(
            request.Title,
            request.Description,
            request.Image,
            DateOnly.Parse(request.Premiere),
            new GenreId(new Guid(request.MovieGenreId)));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
