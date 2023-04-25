using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Movies;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Application.Features.Movies.Queries.GetById;
internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovieByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movieId = new MovieId(request.MovieId);
        var movie = await _unitOfWork.Movies.GetAsync(movieId);

        if (movie is null)
        {
            throw new NotFoundException();
        }

        return movie;
    }
}
