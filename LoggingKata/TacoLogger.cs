using System;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        private static LogLevel logLevel = LogLevel.Fatal;

        public void LogFatal(string log, Exception exception = null)
        {
            if (logLevel >= LogLevel.Fatal)
            {
                Console.WriteLine($"Fatal: {log}, Exception {exception}");
            }
        }

        public void LogError(string log, Exception exception = null)
        {
            if (logLevel >= LogLevel.Error)
            {
                Console.WriteLine($"Error: {log}, Exception {exception}");
            }
        }

        public void LogWarning(string log)
        {
            if (logLevel >= LogLevel.Warn)
            {
                Console.WriteLine($"Warning: {log}");
            }
        }

        public void LogInfo(string log)
        {
            if (logLevel >= LogLevel.Info)
            {
                Console.WriteLine($"Info: {log}");
            }
        }

        public void LogDebug(string log)
        {
            if (logLevel >= LogLevel.Debug)
            {
                Console.WriteLine($"Debug: {log}");
            }
        }
        public void SetLogLevel(LogLevel level)
        {
            var levelText = getLevelText(level);
            logLevel = level;
            Console.WriteLine($"Log Level is set to {levelText}");
        }
        private static string getLevelText(LogLevel level)
        {
            var levelText = "";
            switch (level)
            {
                case LogLevel.Fatal:
                    levelText = "FATAL";
                    break;
                case LogLevel.Error:
                    levelText = "ERROR";
                    break;
                case LogLevel.Warn:
                    levelText = "WARN";
                    break;
                case LogLevel.Info:
                    levelText = "INFO";
                    break;
                case LogLevel.Debug:
                    levelText = "DEBUG";
                    break;
            }
            return levelText;
        }
    }
}
