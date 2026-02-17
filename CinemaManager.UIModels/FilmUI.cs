using CinemaManager.Common;
using CinemaManager.DBModels;

namespace CinemaManager.UIModels;
//This class was separated from DB model to be able to add new films in future
public class FilmUI
{
    private FilmDB _dbModel;
    private string _name;
    private Genre _genre;
    private int _releaseYear;
    private int _durationInMinutes;
    
    public Guid? Id => _dbModel?.Id;
    public string Name
    {
        get => _name;
        set 
        {
            if (_dbModel == null)  _name = value;
        }
    }

    public Genre Genre
    {
        get => _genre;
        set
        {
            if (_dbModel == null) _genre = value;
        }
    }

    public int ReleaseYear
    {
        get => _releaseYear;
        set
        {
            if (_dbModel == null) _releaseYear = value;
        }
    }

    public int DurationInMinutes
    {
        get => _durationInMinutes;
        set
        {
            if (_dbModel == null) _durationInMinutes = value;
        }
    }

    public FilmUI()
    {
        
    }
    
    public FilmUI(FilmDB dbModel)
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
        _genre = dbModel.Genre;
        _releaseYear = dbModel.ReleaseYear;
        _durationInMinutes = dbModel.DurationInMinutes;
    }

    public void SaveToDB()
    {
        if (_dbModel != null) return;
        _dbModel = new FilmDB(_name, _genre, _releaseYear, _durationInMinutes);
    }
}