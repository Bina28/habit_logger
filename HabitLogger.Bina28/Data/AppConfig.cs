using System.Configuration;

namespace HabitLogger.Data;


public static class AppConfig
{
    public static string ConnectionString { get; } =
        ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;
}

