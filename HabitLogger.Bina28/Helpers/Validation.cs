using HabitLogger.Data;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Helpers;
public class Validation
{
    private readonly string _connection;

    public Validation()
    {
        _connection = AppConfig.ConnectionString;
    }
    public bool RecordExist(int id)
    {
        using (var db = new SqliteConnection(_connection))
        {
            db.Open();
            string query = "SELECT COUNT(1) FROM coding WHERE Id=@id";
            using (var cmd = new SqliteCommand(query, db))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return (long)cmd.ExecuteScalar() > 0; 
            }
        }
    }


    public  bool IsValidDate(string date)
    {
        string format = "yyyy-MM-dd";

  
        return DateTime.TryParseExact(date, format, null, System.Globalization.DateTimeStyles.None, out _);
    }
}
