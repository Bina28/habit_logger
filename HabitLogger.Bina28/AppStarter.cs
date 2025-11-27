using HabitLogger.Data;

namespace HabitLogger;

public class AppStarter
{
    private readonly DbRepository _repository;

    public AppStarter(DbRepository repository)
    {
        _repository = repository;
    }
    public void Run()
    {
        string? input;
        bool isValid = false;
        do
        {
            Console.WriteLine(@$"------------------------------------------------
                MAIN MENU
                What would you like to do:  
                0 - {MenuOption.Exit}
                1 - {MenuOption.View}   
                2 - {MenuOption.Insert} 
                3 - {MenuOption.Update}   
                4 - {MenuOption.Delete}
         ------------------------------------------------
                Enter your option: ");
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "0":
                    return;
                case "1":
                    _repository.View();
                    break;
                case "2":
                    _repository.Insert();
                    break;
                case "3":
                    _repository.Update();
                    break;
                case "4":
                    _repository.Delete();
                    break;
                default:
                    isValid = false;
                    break;
            }
        } while (string.IsNullOrEmpty(input) || isValid);
    }
}
