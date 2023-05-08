using MapsterMapper;
using MediatR;
using Movies.Application.Dtos.Movies.Responses;
using Movies.Application.Interfaces;

namespace Movies.Application.Features.Movies.Queries.GetAll;
internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ICollection<MovieResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<MovieResponse>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _unitOfWork.Movies.GetAllAsync();
        
        var genrieIds =  movies.Select(e => e.GenreId).ToList();
        var genries = await _unitOfWork.Genres.FindAllAsync(e => genrieIds.Contains(e.Id));


        var moviesDto = movies.Select(movie =>
            _mapper.Map<MovieResponse>(
                (movie, genries.FirstOrDefault(e => e.Id == movie.GenreId))))
            .ToList();

        return moviesDto;
    }
}
