using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Features.Movies.Queries.GetAll;
internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ICollection<Movie>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Movies.GetAllAsync();
    }
}
