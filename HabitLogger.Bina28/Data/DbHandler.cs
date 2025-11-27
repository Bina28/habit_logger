using Microsoft.Data.Sqlite;

namespace HabitLogger.Data;
public class DbHandler
{

    private static void ViewData()
    {
        using var db = new SqliteConnection(connectionString);
        db.Open();
        string sqlQuery = "SELECT * FROM coding";
        using var cmd = new SqliteCommand(sqlQuery, db);
        using SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id {reader["Id"]}: Date: {reader["Date"]}, Duration: {reader["Duration"]}");

        }
    }

    private static void InsertData()
    {
        string date = DateInput();
        int duration = DurationInput();
        using var db = new SqliteConnection(connectionString);
        db.Open();
        string insertQuery = "INSERT INTO coding (Date, Duration) VALUES (@date, @duration)";
        using var cmd = new SqliteCommand(insertQuery, db);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@duration", duration);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"\nThe record with the date: {date} and duration: {duration} has been successfully saved to the database.");
    }

    private static void DeleteHistory()
    {
        Console.WriteLine("To delete a record, please provide the ID of that record.");
        int id = IdInput();

        if (!RecordExist(id))
        {
            Console.WriteLine($"No record found with the ID {id}. Update operation cannot be performed.");
            return; // Exit the method if the record doesn't exist
        }

        using var db = new SqliteConnection(connectionString);
        db.Open();
        string deleteQuery = "DELETE FROM coding WHERE Id=@id";
        using var cmd = new SqliteCommand(deleteQuery, db);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"The record with the id: {id} has been successfully deleted from the database.");
    }

    private static void UpdateData()
    {
        Console.WriteLine("To update a record, please provide the ID along with the new values for the date and duration.");
        int id = IdInput();
        if (!RecordExist(id))
        {
            Console.WriteLine($"No record found with the ID {id}. Update operation cannot be performed.");
            return; // Exit the method if the record doesn't exist
        }
        string date = DateInput();
        int duration = DurationInput();

        using var db = new SqliteConnection(connectionString);
        db.Open();

        string updateQuery = "UPDATE coding SET Date=@date, Duration=@duration WHERE Id=@id";
        using var cmd = new SqliteCommand(updateQuery, db);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@duration", duration);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"The record with the id {id} has been successfully updated.");
    }

}
