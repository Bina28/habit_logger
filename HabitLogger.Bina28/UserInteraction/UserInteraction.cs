namespace HabitLogger.UserInteraction;

public class UserInteraction
{

    private static int DurationInput()
    {
        int duration;
        Console.Write("Enter the duration: ");
        while (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for duration.");
            Console.Write("Enter the duration: ");
        }
        return duration;
    }

    private static string DateInput()
    {
        bool isValidInput = false;
        string date = "";
        string format = "yyyy-MM-dd";
        while (!isValidInput)
        {
            Console.WriteLine("Do you want to enter today's day? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                isValidInput = true;
                date = DateTime.Now.ToString(format);
            }
            else if (userInput == "n")
            {
                isValidInput = true;
                Console.Write($"Enter a date ({format}): ");
                date = Console.ReadLine();
                while (!IsValidDate(date))
                {
                    Console.WriteLine($"Invalid date format. Please use {format}.");
                    Console.Write($"Enter a date ({format}): ");
                    date = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter 'y' or 'n'.");
            }
        }
        return date;
    }




    private static int IdInput()
    {
        int id;
        Console.Write("Enter the ID: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for ID.");
            Console.Write("Enter the ID: ");
        }
        return id;
    }


}
