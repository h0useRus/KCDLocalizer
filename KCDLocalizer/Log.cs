using System;
using System.IO;

namespace NSW.KCDLocalizer
{
    public static class Log
    {
        private static StreamWriter _stream;
        

        public static void Start()
        {
            _stream = File.CreateText($"KCDLocalizer.log");
        }

        public static void Stop()
        {
            _stream.Flush();
            _stream.Close();
        }

        public static void LogException(Exception exception)
        {
            _stream.WriteLine($"{DateTime.UtcNow:u} | Exception | {exception}");
        }

        public static void LogInfo(string title, string value)
        {
            _stream.WriteLine($"{DateTime.UtcNow:u} | {title} | {value}");
        }
    }
}