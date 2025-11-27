using HabitLogger.Data;

namespace HabitLogger;

public class AppStarter
{
    DatabaseManager databaseManager = new();
    databaseManager.CreateTable(connectionString);
		bool continueOperation = true;
		while (continueOperation)
		{
			Console.WriteLine("------------------------------------------------");
			Console.WriteLine("MAIN MENU" +
				"\nWhat would you like to do:   " +
				" \n0 - Close application   " +
				" \n1 - View all data   " +
				" \n2 - Insert new record   " +
				" \n3 - Update record   " +
				" \n4 - Delete record\n");
			Console.WriteLine("------------------------------------------------");
			Console.Write("Enter your option: ");
			string? input = Console.ReadLine();
    Console.WriteLine();
			switch (input.ToLower())
			{
				case "0":
					continueOperation = false;
					break;
				case "1":
					ViewData();
					break;
				case "2":
					InsertData();
					break;
				case "3":
					UpdateData();
					break;
				case "4":
					DeleteHistory();
					break;
				default:
					Console.WriteLine("Invalid option, please try again.");
					break;
			}

			if (continueOperation) // Only ask if we haven't chosen to exit
			{
				Console.WriteLine("\nDo you want to perform another operation? (y/n)");
				string userResponse = Console.ReadLine().ToLower();
				if (userResponse != "y")
				{
					continueOperation = false;
				}
				Console.Clear();
			}
		}
}
