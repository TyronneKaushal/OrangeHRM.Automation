using Serilog;

namespace OrangeHRM.Automation.Utilities
{
    public static class Logger
    {
        static Logger()
        {
            var logsDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Logs");

            Directory.CreateDirectory(logsDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logsDirectory, "automation-.log"),
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Info(string message)
        {
            Log.Information(message);
        }

        public static void Error(string message, Exception exception)
        {
            Log.Error(exception, message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Warning(string message)
        {
            Log.Warning(message);
        }
    }
}