using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace CustomLogger.ColorConsoleLogger
{
    #region snippet
    public class ColorConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ColorConsoleLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, ColorConsoleLogger> _loggers = new ConcurrentDictionary<string, ColorConsoleLogger>();

        public ColorConsoleLoggerProvider(ColorConsoleLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new ColorConsoleLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
    #endregion
}
