using Microsoft.Extensions.DependencyInjection;

namespace WebPageFetcher
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebPageFetcher(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<WebPageFetcher>();
        }
    }
}
