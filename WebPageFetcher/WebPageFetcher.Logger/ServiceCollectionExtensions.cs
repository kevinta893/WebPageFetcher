using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebPageFetcher.Logger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
        }
    }
}
