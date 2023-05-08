using MapsterMapper;
using MediatR;
using Movies.Application.Dtos.Genre.Responses;
using Movies.Application.Interfaces;

namespace Movies.Application.Features.Genres.Queries.GetAll;
internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, ICollection<GenreResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllGenresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<GenreResponse>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _unitOfWork.Genres.GetAllAsync();

        var genriesDto = _mapper.Map<ICollection<GenreResponse>>(genres);

        return genriesDto;
    }
}
