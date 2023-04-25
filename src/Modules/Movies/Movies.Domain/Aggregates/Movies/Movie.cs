using Common.Domain.DDD;
using Movies.Domain.Aggregates.Genres.ValueObjects;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Domain.Aggregates.Movies;
public sealed class Movie : AggregateRoot<MovieId>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public DateOnly Premiere { get; private set; }
    public GenreId GenreId { get; private set; }

    public Movie(string title, string description, string image, DateOnly premiere, GenreId genreId) 
        : base(new MovieId())
    {
        Title = title;
        Description = description;
        Image = image;
        Premiere = premiere;
        GenreId = genreId;
    }

    public void Update(string title, string description, string image, DateOnly premiere, GenreId genreId)
    {
        Title = title;
        Description = description;
        Image = image;
        Premiere = premiere;
        GenreId = genreId;
    }

    private Movie() : base(new MovieId()) { }
}
