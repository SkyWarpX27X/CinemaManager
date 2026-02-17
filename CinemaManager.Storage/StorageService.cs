using CinemaManager.DBModels;

namespace CinemaManager.Storage;

public class StorageService
{
    private List<HallDB> _halls;
    private List<SessionDB> _sessions;
    private List<FilmDB>  _films;

    public IEnumerable<HallDB> GetAllHalls()
    {
        LoadData();
        return _halls.ToList();
    }

    public IEnumerable<SessionDB> GetSessions(Guid hallId)
    {
        LoadData();
        return _sessions.Where(s => s.HallId == hallId).ToList();
    }

    public IEnumerable<FilmDB> GetAllFilms()
    {
        LoadData();
        return _films.ToList();
    }

    public FilmDB GetFilm(Guid filmId)
    {
        return GetAllFilms().Where(f => f.Id == filmId).First();
    }
    
    private void LoadData()
    {
        if (_halls != null && _sessions != null && _films != null) return;
        _halls = FakeStorage.Halls;
        _sessions = FakeStorage.Sessions;
        _films = FakeStorage.Films;
    }
}