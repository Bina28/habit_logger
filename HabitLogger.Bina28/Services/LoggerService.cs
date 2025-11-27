using HabitLogger.Data;
using HabitLogger.UserInteraction;

namespace HabitLogger.Services;

public class LoggerService : ILoggerService
{
    private readonly DbRepository _repository;

    public LoggerService( DbRepository repository)
    {
       
        _repository = repository;
    }

    public void View()
    {
        var records = _repository.GetAll();
        if (records.Count > 0)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"Id {record.Id}: Date: {record.Date}, Duration: {record.Duration}");
            }
        }
        else
        {
            Console.WriteLine("No records found");
        }
    }

    public void Insert()
    {
        string date = UserConsoleInput.DateInput();
        int duration = UserConsoleInput.DurationInput();
        bool success = _repository.Insert(date, duration);

        Console.WriteLine(success ?
            "Record inserted successfully."
            : "Failed to insert record.");
    }

    public void Delete()
    {
        Console.WriteLine("To delete a record, please provide the ID of that record.");
        string id = UserConsoleInput.IdInput();

        bool success = _repository.Delete(id);
        Console.WriteLine(success ?
       "Record deleted successfully."
       : "Failed to delelte record.");

    }

    public void Update()
    {
        Console.WriteLine("To update a record, please provide the ID along with the new values for the date and duration.");
        string id = UserConsoleInput.IdInput();
        string date = UserConsoleInput.DateInput();
        int duration = UserConsoleInput.DurationInput();
        bool success = _repository.Update(id, date, duration);
        Console.WriteLine(success ?
    "Record updated successfully."
    : "Failed to update record.");

    }

}
