using Common.Domain.DDD;

namespace Movies.Domain.Aggregates.Movies;
public sealed class Movie : AggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public DateOnly Premiere { get; private set; }
    public Guid GenreId { get; private set; }

    public Movie(string title, string description, string image, DateOnly premiere, Guid genreId) 
        : base(Guid.NewGuid())
    {
        Title = title;
        Description = description;
        Image = image;
        Premiere = premiere;
        GenreId = genreId;
    }

    public void Update(string title, string description, string image, DateOnly premiere, Guid genreId)
    {
        Title = title;
        Description = description;
        Image = image;
        Premiere = premiere;
        GenreId = genreId;
    }

    private Movie() : base(Guid.NewGuid()) { }
}
