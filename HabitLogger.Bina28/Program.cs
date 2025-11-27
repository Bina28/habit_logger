using HabitLogger.Data;
using HabitLogger.Helpers;
using HabitLogger.Services;
using HabitLogger.UserInteraction;

namespace HabitLogger;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new();
        databaseManager.CreateTable();      
        var repository = new DbRepository();
        var service = new LoggerService(repository);
        var appStarter = new AppStarter(service);
        while (true)
        {
        appStarter.Run();
        }

    }
}
