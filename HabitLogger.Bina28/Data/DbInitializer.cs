using Microsoft.Data.Sqlite;

namespace HabitLogger.Data;

public class DbInitializer
{
    private readonly string _connection;

    public DbInitializer()
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