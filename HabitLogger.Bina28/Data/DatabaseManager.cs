using Microsoft.Data.Sqlite;

namespace HabitLogger.Data;

public class DatabaseManager
{
    private readonly string _connection;

    public DatabaseManager()
    {
        _connection = AppConfig.ConnectionString;

    }
public  void CreateTable()
	{
        using var connection = new SqliteConnection(_connection);
        connection.Open();

        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText = "CREATE TABLE IF NOT EXISTS coding (" +
                         "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                         "Date TEXT, " +
                         "Duration INTEGER)";

        tableCmd.ExecuteNonQuery();

        connection.Close();
    }
}