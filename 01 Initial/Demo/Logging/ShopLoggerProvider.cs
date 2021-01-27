using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Demo.Logging
{
    public class ShopLoggerProvider : ILoggerProvider
    {
        private ShopLoggerConfiguration Configuration { get; }
        private ConcurrentDictionary<string, ShopLogger> Loggers { get; }
        private Func<LogSink> SinkFactory { get; }

        public ShopLoggerProvider(ShopLoggerConfiguration configuration, Func<LogSink> sinkFactory)
        {
            this.Configuration = configuration;
            this.Loggers = new ConcurrentDictionary<string, ShopLogger>();
            this.SinkFactory = sinkFactory;
        }

        public ILogger CreateLogger(string categoryName) =>
            this.Loggers.GetOrAdd(categoryName, name => new ShopLogger(this.Configuration, this.SinkFactory));

        public void Dispose() => this.Loggers.Clear();
    }
}
