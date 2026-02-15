namespace CinemaManager.DBModels;

public class SessionDB
{
    //Id is generated once during creation and cannot be changed later
    public Guid Id { get; }
    public Guid HallId  { get; set;  }
    //Session is created for specific film and it cannot be changed
    public Guid FilmId { get; }
    public DateTime StartTime { get; set; }

    public SessionDB(Guid hallId, Guid filmId, DateTime startTime)
    {
        Id = Guid.NewGuid();
        HallId = hallId;
        FilmId = filmId;
        StartTime = startTime;
    }
}