using Common.Domain.DDD;

namespace Movies.Domain.Aggregates.Genres;
public sealed class Genre : AggregateRoot
{
    public string Name { get; private set; }

    public Genre(string name)
        : base(Guid.NewGuid())
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }

    private Genre() : base(Guid.NewGuid()) { }

}
