using System;

namespace ConsoleApp10
{
    enum LogLevel
    {
        Debug = 10, Info = 20, Warning = 30, Error = 40, Critical = 50
    }
    class LogEntry
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return $"[{Time}] [{Level, 8}] {Message}";
        }
    }
    static class LogHandler
    {
        static LogEntry[] log = new LogEntry[4];
        public static int Count { get; private set; }

        public static void LogMessage(string message, LogLevel level)
        {
            if (log.Length == Count)
            {
                LogEntry[] newLog = new LogEntry[log.Length * 2];
                for (int i = 0; i < log.Length; i++)
                {
                    newLog[i] = log[i];
                }
                // log.CopyTo(newLog, 0);
                log = newLog;
            }
            /* LogEntry entry = new LogEntry();
            entry.Message = message;
            entry.Level = level;
            entry.Time = DateTime.Now;
            log[Count++] = entry; */
            log[Count++] = new LogEntry() { Message = message, Level = level, Time = DateTime.Now };
        }
        public static void LogDebug(string message)
        {
            LogMessage(message, LogLevel.Debug);
        }
        public static void LogInfo(string message)
        {
            LogMessage(message, LogLevel.Info);
        }
        public static void LogWarning(string message)
        {
            LogMessage(message, LogLevel.Warning);
        }
        public static void LogError(string message)
        {
            LogMessage(message, LogLevel.Error);
        }
        public static void LogCritical(string message)
        {
            LogMessage(message, LogLevel.Critical);
        }
        public static void WriteToFile()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("bullhunter.log");
            for (int i = 0; i < Count; i++) // log.Length lehet akár jóval nagyobb, mint a Count
            {
                sw.WriteLine(log[i]);
            }
            sw.Close();
        }
    }
}
