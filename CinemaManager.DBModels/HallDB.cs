using CinemaManager.Common;

namespace CinemaManager.DBModels;

public class HallDB
{
    //Id is generated once during creation and cannot be changed later
    public Guid Id  { get; }
    public string Name { get; set; }
    public int Seats { get; set; }
    public HallType Type { get; set; }

    public HallDB(string name, int seats, HallType type)
    {
        Id = Guid.NewGuid();
        Name = name;
        Seats = seats;
        Type = type;
    }
}