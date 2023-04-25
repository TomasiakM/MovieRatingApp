using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Genres;

namespace Movies.Application.Features.Genres.Commands.Create;
internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre(request.Name);

        _unitOfWork.Genres.Add(genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
