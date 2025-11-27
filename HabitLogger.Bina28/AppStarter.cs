using HabitLogger.Services;

namespace HabitLogger;

public class AppStarter
{
    private readonly LoggerService _loggerService;

    public AppStarter(LoggerService loggerService)
    {
        _loggerService = loggerService;
    }
    public void Run()
    {
        string? input;
        bool isValid = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@$"
MAIN MENU
What would you like to do:  
0 - {MenuOption.Exit}
1 - {MenuOption.View}   
2 - {MenuOption.Insert} 
3 - {MenuOption.Update}   
4 - {MenuOption.Delete}        
   
Enter your option: ");
            input = Console.ReadLine();

            switch (input?.ToLower())
            {
                case "0":
                    return;
                case "1":
                    _loggerService.View();
                    break;
                case "2":
                    _loggerService.Insert();
                    break;
                case "3":
                    _loggerService.Update();
                    break;
                case "4":
                    _loggerService.Delete();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    isValid = false;
                    break;
            }


        } while (string.IsNullOrEmpty(input) || !isValid);

        Console.WriteLine("\nPress ENTER to return to menu...");
        Console.ReadLine();
    }
}