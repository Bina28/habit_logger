namespace HabitLogger.Domain.Models;

public class HabitRecord
{
    public required string Id { get; set; }
    public required string Date { get; set; }
    public required int Duration { get; set; }
}
