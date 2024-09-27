using System;
namespace TweetRandomFeedItem
{
    public class Helper
    {
        public static T GetEnv<T>(string environmentVariable)
        {
            try
            {
                return (T)Convert.ChangeType(Environment.GetEnvironmentVariable(environmentVariable), typeof(T));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"The environment variable {environmentVariable} is required and missing.");
                throw;
            }
        }

        public static T GetEnv<T>(string environmentVariable, string defaultValue)
        {
            return (T)Convert.ChangeType(Environment.GetEnvironmentVariable(environmentVariable) ?? defaultValue, typeof(T));
        }
    }
}
