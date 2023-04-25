using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Movies;
using Movies.Infrastructure.Persistence.Repositories;

namespace Movies.Infrastructure.Persistence;
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly MovieDbContext _dbContext;

    public IMovieRepository Movies { get; }
    public IGenreRepository Genres { get; }

    public UnitOfWork(MovieDbContext dbContext)
    {
        _dbContext = dbContext;

        Movies = new MovieRepository(_dbContext);
        Genres = new GenreRepository(_dbContext);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
