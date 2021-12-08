using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebPageFetcher.Contracts;
using WebPageFetcher.FileRepository;
using WebPageFetcher.Logger;
using WebPageFetcher.WebClient;

namespace WebPageFetcher
{
    class Program
    {
        public class Options
        {
            [Option('m', "metadata", Required = false, HelpText = "Prints out the metadata for the webpage(s) being fetched.")]
            public bool Metadata { get; set; }

            [Value(0, Required = true, HelpText = "List of URLs to fetch")]
            public IEnumerable<string> Urls { get; set; }
        }

        private ILogger _logger;

        static void Main(string[] args) =>
            new Program().MainAsync(args).GetAwaiter().GetResult();


        private async Task MainAsync(string[] args)
        {
            var options = Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(async o =>
                {
                    var services = ConfigureServices();
                    _logger = services.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();
                    try
                    {
                        var webPageFetcher = services.GetRequiredService<WebPageFetcher>();
                        webPageFetcher.FetchAndSave(o.Urls, o.Metadata).Wait();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "General exception during program execution.");
                        throw;
                    }
                });
        }
        private IServiceProvider ConfigureServices()
        {
            return (new ServiceCollection() as IServiceCollection)
                .AddWebPageFetcher()
                .AddConsoleLogger()
                .AddLocalFileRepository()
                .AddWebClient()
                .AddWebPageMetadataParser()
                .BuildServiceProvider();
        }
    }
}
