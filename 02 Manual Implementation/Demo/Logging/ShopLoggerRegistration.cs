using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Logging
{
    public static class ShopLoggerRegistration
    {
        public static ILoggingBuilder AddShopLogger(this ILoggingBuilder builder, ShopLoggerConfiguration configuration, Func<LogSink> sinkFactory) =>
            builder.AddProvider(new ShopLoggerProvider(configuration, sinkFactory));
    }
}
