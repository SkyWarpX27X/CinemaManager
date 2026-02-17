using CinemaManager.Storage;
using CinemaManager.UIModels;

namespace CinemaManager.ConsoleApp;

internal class Program
{
    internal enum AppState
    {
        Default,
        HallInformation,
        End,
        Exit,
    }
    private static StorageService _storageService;
    private static AppState _appState;
    private static List<HallUI>  _halls;
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Cinema Manager app!");
        _storageService = new StorageService();
        _appState = AppState.Default;
        string? command = null;
        while (_appState != AppState.Exit)
        {
            switch (_appState)
            {
                case AppState.HallInformation:
                    HallInformation(command);
                    break;
                case AppState.Default:
                    DefaultState();
                    break;
            }
            Console.WriteLine("Enter Exit to close application.");
            command = Console.ReadLine();
            ProcessInput(command);
        }
    }

    private static void DefaultState()
    {
        LoadHalls();
        foreach (var hall in _halls)
        {
            Console.WriteLine(hall);
        }
        Console.WriteLine("Enter hall name to see details.");
    }

    private static void LoadHalls()
    {
        if (_halls != null) return;
        _halls = new List<HallUI>();
        foreach (var hall in _storageService.GetAllHalls())
        {
            _halls.Add(new HallUI(hall));
        }
    }

    private static void HallInformation(string? name)
    {
        bool hallExists = false;
        foreach (var hall in _halls)
        {
            if (hall.Name == name)
            {
                hallExists = true;
                hall.LoadSessions(_storageService);
                Console.WriteLine($"{hall.Name} sessions:");
                foreach (var session in hall.Sessions)
                {
                    Console.WriteLine(session);
                }
            }
        }
        if (!hallExists)
            Console.WriteLine("Hall with that name does not exist.");
        else
        {
            Console.WriteLine("Enter Back to go to list of halls.");
            _appState = AppState.End;
        }
    }
    
    private static void ProcessInput(string? command)
    {
        switch (command)
        {
            case "Exit":
                _appState = AppState.Exit;
                Console.WriteLine("Thanks for using the application!");
                break;
            case "Back":
                _appState = AppState.Default;
                break;
            default:
                if (_appState == AppState.Default)
                {
                    _appState = AppState.HallInformation;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }
                break;
        }
    }
    
    
}

