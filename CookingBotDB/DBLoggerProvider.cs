using Microsoft.Extensions.Logging;

namespace CookingBotDB
{
    public class DBLoggerProvider : ILoggerProvider
    {
        private ILogger _logger;

        public DBLoggerProvider(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose() { }
    }
}
