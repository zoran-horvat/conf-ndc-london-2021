using Microsoft.Extensions.Logging;

namespace Demo.Logging
{
    public class ShopLoggerConfiguration
    {
        public LogLevel Level { get; }

        public ShopLoggerConfiguration(LogLevel level)
        {
            this.Level = level;
        }
    }
}
