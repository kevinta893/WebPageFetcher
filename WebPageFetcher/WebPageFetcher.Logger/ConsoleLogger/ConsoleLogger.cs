using Microsoft.Extensions.Logging;
using System;

namespace WebPageFetcher.Logger
{
    /// <summary>
    /// Provides a very basic standard out console logger
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new FakeDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var formattedException = formatter(state, exception);
            Console.WriteLine($"{logLevel} EventId: {eventId.Name} State: {state} Exception:{formattedException}");
        }
    }
}
