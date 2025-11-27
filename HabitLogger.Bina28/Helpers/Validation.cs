using Microsoft.Data.Sqlite;

namespace HabitLogger.Helpers;
public class Validation
{
    private static bool RecordExist(int id)
    {
        using (var db = new SqliteConnection(connectionString))
        {
            db.Open();
            string query = "SELECT COUNT(1) FROM coding WHERE Id=@id";
            using (var cmd = new SqliteCommand(query, db))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return (long)cmd.ExecuteScalar() > 0; // Returns true if the record exists
            }
        }
    }


    private static bool IsValidDate(string date)
    {
        string format = "yyyy-MM-dd";

        // Try to parse the date string
        return DateTime.TryParseExact(date, format, null, System.Globalization.DateTimeStyles.None, out _);
    }
}
