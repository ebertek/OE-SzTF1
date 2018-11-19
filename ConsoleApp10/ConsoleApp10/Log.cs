using System;

namespace ConsoleApp10
{
    enum LogLevel
    {
        Debug, Info, Warning, Error, Critical
    }
    class LogEntry
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    class LogHandler
    {
        private LogEntry[] log;
        public int Count { get; set; }
        public void LogCritical(string message)
        {
        }
        public void LogDebug(string message)
        {
        }
        public void LogError(string message)
        {
        }
        public void LogInfo(string message)
        {
        }
        public void LogMessage(string message)
        {
        }
        public void LogWarning(string message)
        {
        }
        public void WriteToFile()
        {
        }
    }
}
