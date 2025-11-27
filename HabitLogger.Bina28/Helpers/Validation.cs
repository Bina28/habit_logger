namespace HabitLogger.Helpers;
public class Validation
{

    public static bool IsValidDate(string date, string format)
    {
        return DateTime.TryParseExact(date, format, null, System.Globalization.DateTimeStyles.None, out _);
    }
}
