using Common.Domain.Exceptions;
using MapsterMapper;
using MediatR;
using Movies.Application.Dtos.Movies.Responses;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Application.Features.Movies.Queries.GetById;
internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMovieByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movieId = new MovieId(request.MovieId);
        var movie = await _unitOfWork.Movies.GetAsync(movieId);

        if (movie is null)
        {
            throw new NotFoundException();
        }

        var genre = await _unitOfWork.Genres.GetAsync(movie.GenreId);
        var movieDto = _mapper.Map<MovieResponse>((movie, genre));

        return movieDto;
    }
}
