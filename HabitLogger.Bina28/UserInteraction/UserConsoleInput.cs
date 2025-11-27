using HabitLogger.Helpers;

namespace HabitLogger.UserInteraction;

public class UserConsoleInput
{

    public static int DurationInput()
    {
        int duration;
        Console.Write("Enter the duration in minutes: ");
        while (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for duration.");
            Console.Write("Enter the duration: ");
        }
        return duration;
    }

    public static bool GetYesNo(string message)
    {
        string? input;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine()?.Trim().ToLower();

            if (input == "y") return true;
            if (input == "n") return false;

            Console.WriteLine("Invalid input! Please enter 'y' or 'n'.");
        }
        while (true);
    }
    public static string GetValidDate(string format)
    {
        string? date;

        do
        {
            Console.Write($"Enter a date ({format}): ");
            date = Console.ReadLine();

            if (!string.IsNullOrEmpty(date) && Validation.IsValidDate(date, format))
                return date;

            Console.WriteLine($"Invalid date format. Please use {format}.");
        }
        while (true);
    }


    public static string DateInput()
    {
        string format = "yyyy-MM-dd";

        bool useToday = GetYesNo("Do you want to enter today's day? (y/n)");

        if (useToday)
            return DateTime.UtcNow.ToString(format);

        return GetValidDate(format);
    }


    public static string IdInput()
    {
        string id = "";
        Console.Write("Enter the ID: ");
        while (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for ID.");
            Console.Write("Enter the ID: ");
        }
        return id;
    }


}
