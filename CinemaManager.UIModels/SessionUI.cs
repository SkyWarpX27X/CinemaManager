using CinemaManager.DBModels;

namespace CinemaManager.UIModels;

public class SessionUI
{
    private SessionDB _dbModel;
    private Guid _hallId;
    private FilmUI _film;
    private DateTime _startTime;

    public SessionUI(Guid hallId)
    {
        _hallId = hallId;
    }
    public SessionUI(SessionDB dbModel, FilmDB film)
    {
        _dbModel = dbModel;
        _hallId = dbModel.HallId;
        _film = new FilmUI(film);
        _startTime = dbModel.StartTime;
    }
    public Guid? Id => _dbModel?.Id;

    public Guid HallId
    {
        get => _hallId;
        set => _hallId = value;
    }

    public FilmUI Film
    {
        get => _film;
        set
        {
            if(_film == null) _film = value;
        }
    }

    public DateTime StartTime
    {
        get =>  _startTime;
        set => _startTime = value;
    }
    public DateTime EndTime => _startTime + new TimeSpan(0, _film.DurationInMinutes, 0);

    public override string ToString()
    {
        return $"Film: {Film.Name}, Time: {StartTime} - {EndTime.TimeOfDay}";
    }

    public void SaveToDB()
    {
        if (_dbModel != null)
        {
            _dbModel.HallId = _hallId;
            _dbModel.StartTime = _startTime;
        }
        else
        {
            _dbModel = new SessionDB(HallId, Film.Id.Value, StartTime);
        }
    }
}