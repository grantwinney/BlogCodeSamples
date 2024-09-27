using System;
using System.Text.RegularExpressions;

namespace TweetRandomFeedItem
{
    public class Helper
    {
        static readonly Regex invalidChars = new("[- ]");

        public static string SanitizeTagName(string tag)
        {
            return $"#{invalidChars.Replace(tag, "").Replace("#", "sharp").Replace(".", "dot")}";
        }

        public static T GetEnv<T>(string environmentVariable)
        {
            try
            {
                return ConvertVariableType<T>(environmentVariable, Environment.GetEnvironmentVariable(environmentVariable));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"The environment variable {environmentVariable} is missing.");
                throw;
            }
        }

        public static T GetEnv<T>(string environmentVariable, string defaultValue)
        {
            try
            {
                return ConvertVariableType<T>(environmentVariable, Environment.GetEnvironmentVariable(environmentVariable), defaultValue);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"The environment variable {environmentVariable} is missing.");
                throw;
            }
        }

        public static T ConvertVariableType<T>(string variableKey, string variableValue, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(variableValue))
            {
                if (defaultValue != null)
                {
                    Console.WriteLine($"The environment variable {variableKey} returned a null value. Using default value of '{defaultValue}' instead.");
                    return (T)Convert.ChangeType(defaultValue, typeof(T));
                }
                else
                    Console.WriteLine($"The environment variable {variableKey} returned a null value.");
            }

            return (T)Convert.ChangeType(variableValue, typeof(T));
        }
    }
}
