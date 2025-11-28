using HabitLogger.Application.Services;
using HabitLogger.Data;
using HabitLogger.UI;



DbInitializer databaseManager = new();
databaseManager.CreateTable();
var repository = new DbRepository();
var service = new LoggerService(repository);
var appStarter = new AppStarter(service);

while (true)
{
    appStarter.Run();
}
