using CinemaManager.Common;

namespace CinemaManager.DBModels;

public class FilmDB
{
    //Film does not change after release so it's fields cannot be changed
    public Guid Id { get; }
    public string Name { get; }
    public Genre Genre { get; }
    public int ReleaseYear { get; }
    public int Duration { get; }

    public FilmDB(string name, Genre genre, int releaseYear, int duration)
    {
        Id = Guid.NewGuid();
        Name = name;
        Genre = genre;
        ReleaseYear = releaseYear;
        Duration = duration;
    }
}