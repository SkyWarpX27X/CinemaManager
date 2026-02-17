using CinemaManager.Storage;
using CinemaManager.UIModels;

namespace CinemaManager.ConsoleApp;

internal class Program
{
    private enum AppState
    {
        MainMenu,
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
        _appState = AppState.MainMenu;
        string? command = null;
        while (_appState != AppState.Exit)
        {
            switch (_appState)
            {
                case AppState.HallInformation:
                    HallInformation(command);
                    break;
                case AppState.MainMenu:
                    MainMenu();
                    break;
            }
            Console.WriteLine("Enter exit to close application");
            command = Console.ReadLine();
            ProcessInput(command);
        }
    }

    private static void MainMenu()
    {
        if (_halls == null)
        {
            _halls = new List<HallUI>();
            foreach (var hall in _storageService.GetAllHalls())
            {
                _halls.Add(new HallUI(hall));
            }
        }
        foreach (var hall in _halls)
        {
            Console.WriteLine(hall);
        }
        Console.WriteLine("Enter hall name to see it's sessions");
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
                if (hall.Sessions.Count == 0)
                {
                    Console.WriteLine($"{hall.Name} doesn't have any sessions");
                }
                else
                {
                    Console.WriteLine($"{hall.Name} sessions:");
                    foreach (var session in hall.Sessions)
                    {
                        Console.WriteLine(session);
                    }
                }
            }
        }
        if (!hallExists)
            Console.WriteLine("Hall with that name does not exist");
        else
        {
            Console.WriteLine("Enter back to go to list of halls");
            _appState = AppState.End;
        }
    }
    
    private static void ProcessInput(string? command)
    {
        switch (command)
        {
            case "Exit":
            case "exit":
                _appState = AppState.Exit;
                Console.WriteLine("Thanks for using the application");
                break;
            case "Back":
            case "back":    
                _appState = AppState.MainMenu;
                break;
            default:
                if (_appState == AppState.MainMenu)
                {
                    _appState = AppState.HallInformation;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
                break;
        }
    }
    
    
}

