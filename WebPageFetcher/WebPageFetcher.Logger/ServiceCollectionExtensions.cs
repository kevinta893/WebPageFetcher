using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebPageFetcher.Logger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console()
                .CreateLogger();

            serviceCollection.AddLogging(x =>
            {
                x.ClearProviders();
                x.AddSerilog(logger);
            });

            return serviceCollection;
        }
    }
}
