using System;

namespace SampleLibrary
{
    public class Main
    {
        public void PrintSettings()
        {
            Console.WriteLine($"Application Name: {LogSettings.Instance.ApplicationName}");
            Console.WriteLine($"Log Path: {LogSettings.Instance.LogFilePath}");
            Console.WriteLine($"Log Date Format: {LogSettings.Instance.DateFormat}");
            Console.WriteLine($"Include Date? {(LogSettings.Instance.IncludeDate ? "Yes" : "No")}");
            Console.WriteLine($"Log Level: {LogSettings.Instance.Level}");
        }
    }
}
