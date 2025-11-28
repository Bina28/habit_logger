using HabitLogger.Domain.Models;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Data;
public class DbRepository
{
    private readonly string _connection;

    public DbRepository()
    {
        _connection = AppConfig.ConnectionString;
    }
    public List<HabitRecord> GetAll()
    {
        var records = new List<HabitRecord>();
        using var db = new SqliteConnection(_connection);
        db.Open();
        string sqlQuery = "SELECT * FROM coding";
        using var cmd = new SqliteCommand(sqlQuery, db);
        using SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            records.Add(new HabitRecord
            {
                Id = reader["Id"].ToString()!,
                Date = reader["Date"].ToString()!,
                Duration = Convert.ToInt32(reader["Duration"])

            });
        }
        return records;
    }

    public bool Insert(string date, int duration)
    {

        using var db = new SqliteConnection(_connection);
        db.Open();
        string insertQuery = "INSERT INTO coding (Date, Duration) VALUES (@date, @duration)";
        using var cmd = new SqliteCommand(insertQuery, db);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@duration", duration);
        return cmd.ExecuteNonQuery() > 0;

    }

    public bool Delete(string id)
    {

        using var db = new SqliteConnection(_connection);
        db.Open();
        string deleteQuery = "DELETE FROM coding WHERE Id=@id";
        using var cmd = new SqliteCommand(deleteQuery, db);
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery() > 0;

    }

    public bool Update(string id, string date, int duration)
    {
        using var db = new SqliteConnection(_connection);
        db.Open();
        string updateQuery = "UPDATE coding SET Date=@date, Duration=@duration WHERE Id=@id";
        using var cmd = new SqliteCommand(updateQuery, db);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@duration", duration);
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery() > 0;

    }

}
