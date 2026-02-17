using CinemaManager.Common;
using CinemaManager.DBModels;
using CinemaManager.Storage;

namespace CinemaManager.UIModels;

public class HallUI
{
    private HallDB _dbModel;
    private string _name;
    private int _seats;
    private HallType _hallType;
    private List<SessionUI> _sessions;
    
    public HallUI()
    {
        _sessions = new List<SessionUI>();
    }
    
    public HallUI(HallDB dbModel) : this()
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
        _seats = dbModel.Seats;
        _hallType = dbModel.Type;
    }
    
    public Guid? Id => _dbModel?.Id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Seats
    {
        get => _seats;
        set => _seats = value;
    }

    public HallType Type
    {
        get => _hallType;
        set => _hallType = value;
    }
    public IReadOnlyList<SessionUI> Sessions =>  _sessions;

    public int TotalDurabilityInMinutes
    {
        get
        {
            var total = 0;
            foreach (var session in _sessions)
            {
                total += session.Film.DurationInMinutes;
            }
            return total;
        }
    }

    public void LoadSessions(StorageService storageService)
    {
        if (Id == null || _sessions.Count > 0) return;
        foreach (var session in storageService.GetSessions(Id.Value))
        {
            _sessions.Add(new SessionUI(session, storageService.GetFilm(session.FilmId)));
        }
    }

    public override string ToString()
    {
        return $"{Name}, {Type} with {Seats} seats";
    }

    public void SaveToDB()
    {
        if (_dbModel != null)
        {
            _dbModel.Name = Name;
            _dbModel.Seats = Seats;
            _dbModel.Type = Type;
        }
        else
        {
            _dbModel = new HallDB(Name, Seats, Type);
        }
    }
}