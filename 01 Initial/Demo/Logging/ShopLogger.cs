using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Reflection;

namespace Demo.Logging
{
    public class ShopLogger : ILogger
    {
        private ShopLoggerConfiguration Configuration { get; }
        private LogLevel LogLevel => this.Configuration.Level;
        private Lazy<LogSink> Sink { get; }
 
        public ShopLogger(ShopLoggerConfiguration configuration, Func<LogSink> sinkFactory)
        {
            this.Configuration = configuration;
            this.Sink = new Lazy<LogSink>(sinkFactory);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (this.IsEnabled(logLevel) && 
                typeof(TState).GetFields(BindingFlags.Instance | BindingFlags.NonPublic) is FieldInfo[] fields && 
                fields.Length >= 6 && 
                fields[2].FieldType == typeof(CommandType) && 
                fields[5].FieldType == typeof(string) &&
                fields[5]?.GetValue(state) is string commandText && 
                !string.IsNullOrEmpty(commandText))
            {
                this.Sink.Value.Append(commandText);
            }
        }

        public bool IsEnabled(LogLevel logLevel) => this.LogLevel == logLevel;

        public IDisposable BeginScope<TState>(TState state) => default;
    }
}
