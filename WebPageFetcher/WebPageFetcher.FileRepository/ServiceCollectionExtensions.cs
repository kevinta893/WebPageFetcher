using Microsoft.Extensions.DependencyInjection;
using WebPageFetcher.Contracts;
using WebPageFetcher.FileRepository.Service;

namespace WebPageFetcher.FileRepository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalFileRepository(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<ILocalFileRepository, LocalFileService>();
        }
    }
}
