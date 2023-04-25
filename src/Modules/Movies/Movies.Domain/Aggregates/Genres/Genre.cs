using Common.Domain.DDD;
using Movies.Domain.Aggregates.Genres.ValueObjects;

namespace Movies.Domain.Aggregates.Genres;
public sealed class Genre : AggregateRoot<GenreId>
{
    public string Name { get; private set; }

    public Genre(string name)
        : base(new GenreId())
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }

    private Genre() : base(new GenreId()) { }

}
