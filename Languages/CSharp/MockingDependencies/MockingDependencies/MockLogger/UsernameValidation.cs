using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Text.RegularExpressions;

namespace MockingDependencies.MockLogger
{
    public class UsernameValidation
    {
        private readonly Logger logger;

        public UsernameValidation()
        {
            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new FileTarget("logfile") { FileName = "loggermethod1.txt" };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            // Create new instance of logger
            logger = LogManager.GetCurrentClassLogger();
        }

        public bool IsUsernameAlphaOnly(string username)
        {
            try
            {
                logger.Debug($"{nameof(IsUsernameAlphaOnly)}: Testing whether {username} is valid.");
                var isMatch = Regex.IsMatch(username, "^[A-Za-z]+$");
                logger.Debug($"{nameof(IsUsernameAlphaOnly)}: {username} is {(isMatch ? "a valid" : "an invalid")} username.");
                return isMatch;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"{nameof(IsUsernameAlphaOnly)}: Guess {username} wasn't valid. :/");
                return false;
            }
        }
    }
}
