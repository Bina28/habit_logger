using HabitLogger.Data;
using HabitLogger.Helpers;
using HabitLogger.UserInteraction;

namespace HabitLogger;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new();
        databaseManager.CreateTable();
        var validation = new Validation();
        var userInput = new UserConsoleInput(validation);
        var repository = new DbRepository(validation, userInput);
        var appStarter = new AppStarter(repository);
        appStarter.Run();
    }
}
