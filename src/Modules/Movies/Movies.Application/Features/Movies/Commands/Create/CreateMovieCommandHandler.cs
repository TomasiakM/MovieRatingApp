using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Features.Movies.Commands.Create;
internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie(
            request.Title,
            request.Description,
            request.Image,
            DateOnly.Parse(request.Premiere),
            new Guid(request.GenreId));

        _unitOfWork.Movies.Add(movie);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
