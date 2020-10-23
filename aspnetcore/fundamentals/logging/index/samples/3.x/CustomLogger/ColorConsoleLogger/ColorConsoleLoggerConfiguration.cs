using System;
using Microsoft.Extensions.Logging;

namespace CustomLogger.ColorConsoleLogger
{
    #region snippet
    public class ColorConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
    #endregion
}
