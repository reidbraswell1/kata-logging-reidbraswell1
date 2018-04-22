using System;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        public const int fatal = 1;
        public const int error = 2;
        public const int warn = 3;
        public const int info = 4;
        public const int debug = 5;

        private static int logLevel = fatal;

        public void LogFatal(string log, Exception exception = null)
        {
            if (logLevel >= fatal)
            {
                Console.WriteLine($"Fatal: {log}, Exception {exception}");
            }
        }

        public void LogError(string log, Exception exception = null)
        {
            if (logLevel >= error)
            {
                Console.WriteLine($"Error: {log}, Exception {exception}");
            }
        }

        public void LogWarning(string log)
        {
            if (logLevel >= warn)
            {
                Console.WriteLine($"Warning: {log}");
            }
        }

        public void LogInfo(string log)
        {
            if (logLevel >= info)
            {
                Console.WriteLine($"Info: {log}");
            }
        }

        public void LogDebug(string log)
        {
            if (logLevel >= debug)
            {
                Console.WriteLine($"Debug: {log}");
            }
        }
        public void SetLogLevel(int level)
        {
            var levelText = "";
            if (level > 0 && level < 6)
            {
                logLevel = level;
                levelText = getLevelText(level);
                Console.WriteLine($"Log level set to {levelText}");
            }
            else
            {
                levelText = getLevelText(level);
                Console.WriteLine($"Log Level Invalid {level} currently set to {levelText}");
            }
        }
        private static string getLevelText(int level)
        {
            var levelText = "";
            switch (level)
            {
                case TacoLogger.fatal:
                    levelText = "FATAL";
                    break;
                case TacoLogger.error:
                    levelText = "ERROR";
                    break;
                case TacoLogger.warn:
                    levelText = "WARN";
                    break;
                case TacoLogger.info:
                    levelText = "INFO";
                    break;
                case TacoLogger.debug:
                    levelText = "DEBUG";
                    break;
            }
            return levelText;
        }
    }
}
