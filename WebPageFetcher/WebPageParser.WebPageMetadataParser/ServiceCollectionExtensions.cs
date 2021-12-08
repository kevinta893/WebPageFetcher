using Microsoft.Extensions.DependencyInjection;
using WebPageFetcher.Contracts;
using WebPageParser.WebPageMetadataParser;
using WebPageParser.WebPageMetadataParser.Services;

namespace WebPageFetcher.WebClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebPageMetadataParser(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IWebPageMetadataService, WebPageMetadataParser>();

            return serviceCollection;
        }
    }
}
