using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Genres;

namespace Movies.Application.Features.Genres.Queries.GetAll;
internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<Genre>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Genres.GetAllAsync();
    }
}
