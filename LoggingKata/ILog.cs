﻿using System;
namespace LoggingKata
{
    public interface ILog
    {
        void LogFatal(string log, Exception exception = null);
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogDebug(string log);
        void SetLogLevel(LogLevel level);
    }
    public enum LogLevel
    {
        Fatal,
        Error,
        Warn,
        Info,
        Debug
    }
}
