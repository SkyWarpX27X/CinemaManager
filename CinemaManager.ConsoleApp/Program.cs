using CinemaManager.Storage;
using CinemaManager.UIModels;

namespace CinemaManager.ConsoleApp;

internal class Program
{
    private enum AppState
    {
        MainMenu,
        HallInformation,
        AllSessions,
        End,
        Exit,
    }
    private static StorageService _storageService;
    private static AppState _appState;
    private static List<HallUI>  _halls;
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Cinema Manager app\n");
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
                case AppState.AllSessions:
                    AllSessions();
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
        Console.WriteLine("\nEnter hall name to see it's sessions");
        Console.WriteLine("Enter all to see all sessions");
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
            Console.WriteLine("\nEnter back to go to list of halls");
            _appState = AppState.End;
        }
    }

    private static void AllSessions()
    {
        foreach (var hall in _halls)
        {
            hall.LoadSessions(_storageService);
            foreach (var session in hall.Sessions)
            {
                Console.WriteLine(session);
            }
        }
        Console.WriteLine("\nEnter back to go to list of halls");
    }
    
    private static void ProcessInput(string? command)
    {
        if (command == "Exit" ||  command == "exit")
        {
            _appState = AppState.Exit;
            Console.WriteLine("Thanks for using the application");
        }
        else
        {
            if (_appState == AppState.MainMenu)
            {
                if (command == "All" || command == "all")
                {
                    _appState = AppState.AllSessions;
                }
                else
                {
                    _appState = AppState.HallInformation;
                }
            }
            else
            {
                if (command == "Back" || command == "back")
                {
                    _appState = AppState.MainMenu;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }
    }
    
    
}

