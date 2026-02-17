using CinemaManager.Common;
using CinemaManager.DBModels;

namespace CinemaManager.Storage;

internal static class FakeStorage
{
    private static readonly List<HallDB> _halls;
    private static readonly List<SessionDB> _sessions;
    private static readonly List<FilmDB>  _films;

    internal static List<HallDB> Halls => _halls.ToList();
    internal static List<SessionDB> Sessions => _sessions.ToList();
    internal static List<FilmDB> Films => _films.ToList();

    static FakeStorage()
    {
        var hall1SuperLux = new HallDB("Hall N1 Super Lux", 35, HallType.TwoD);
        var hall2ScreenX = new HallDB("Hall N2", 250, HallType.ScreenX);
        var hall3Imax = new HallDB("Hall N3", 180, HallType.IMAX);
        _halls = new List<HallDB>{hall1SuperLux, hall2ScreenX, hall3Imax};
        var barbie = new FilmDB("Barbie", Genre.Comedy, 2023, 114);
        var oppenheimer = new FilmDB("Oppenheimer", Genre.Thriller, 2023, 180);
        var cars = new FilmDB("Cars", Genre.Cartoon, 2006, 117);
        var pussInBoots = new FilmDB("Puss in Boots: The Last Wish", Genre.Comedy, 2022, 102);
        var interstellar = new FilmDB("Interstellar", Genre.SciFi, 2014, 169);
        _films = new List<FilmDB>{barbie, oppenheimer, cars, pussInBoots, interstellar};
        _sessions = new List<SessionDB>
        {
            new SessionDB(hall1SuperLux.Id, barbie.Id, new DateTime(new DateOnly(2026, 2, 16), new TimeOnly(16, 30))),
            new SessionDB(hall1SuperLux.Id, oppenheimer.Id, new DateTime(new DateOnly(2026, 2, 17), new TimeOnly(10, 0))),
            new SessionDB(hall2ScreenX.Id, cars.Id, new DateTime(new DateOnly(2026, 2, 16), new TimeOnly(8, 30))),
            new SessionDB(hall2ScreenX.Id, pussInBoots.Id, new DateTime(new DateOnly(2026, 2, 16), new TimeOnly(12, 15))),
            new SessionDB(hall2ScreenX.Id, interstellar.Id, new DateTime(new DateOnly(2026, 2, 16), new TimeOnly(16, 30))),
            new SessionDB(hall2ScreenX.Id, barbie.Id, new DateTime(new DateOnly(2026, 2, 17), new TimeOnly(11, 45))),
            new SessionDB(hall2ScreenX.Id, oppenheimer.Id, new DateTime(new DateOnly(2026, 2, 17), new TimeOnly(12, 30))),
            new SessionDB(hall2ScreenX.Id, pussInBoots.Id, new DateTime(new DateOnly(2026, 2, 18), new TimeOnly(16, 20))),
            new SessionDB(hall2ScreenX.Id, cars.Id, new DateTime(new DateOnly(2026, 3, 1), new TimeOnly(14, 50))),
            new SessionDB(hall2ScreenX.Id, interstellar.Id, new DateTime(new DateOnly(2026, 3, 15), new TimeOnly(20, 30))),
            new SessionDB(hall2ScreenX.Id, oppenheimer.Id, new DateTime(new DateOnly(2026, 3, 31), new TimeOnly(9, 25))),
            new SessionDB(hall2ScreenX.Id, cars.Id, new DateTime(new DateOnly(2026, 3, 31), new TimeOnly(21, 40)))
        };
    }
}