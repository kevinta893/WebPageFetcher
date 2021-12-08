using Microsoft.Extensions.DependencyInjection;
using WebPageFetcher.Contracts;
using WebPageFetcher.WebClient.Services;

namespace WebPageFetcher.WebClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient();

            serviceCollection.AddScoped<IWebClient, WebClientService>();

            return serviceCollection;
        }
    }
}
