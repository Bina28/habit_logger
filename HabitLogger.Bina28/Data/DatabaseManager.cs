using Microsoft.Data.Sqlite;

namespace HabitLogger.Data;

public class DatabaseManager
{
public void CreateTable(string connectionString)
	{
        using var connection = new SqliteConnection(connectionString);
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