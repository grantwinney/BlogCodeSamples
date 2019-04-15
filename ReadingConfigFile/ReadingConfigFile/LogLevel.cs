namespace SampleLibrary
{
    /// <summary>
    /// Represents the minimal importance level of messages to log
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Log nothing, effectively disabling logging
        /// </summary>
        None = 0,

        /// <summary>
        /// Log informational messages, as well as warnings and errors
        /// </summary>
        Info = 1,

        /// <summary>
        /// Log warnings and errors, but not informational messages
        /// </summary>
        Warn = 2,

        /// <summary>
        /// Log errors only
        /// </summary>
        Error = 3,
    }
}
