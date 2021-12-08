using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebPageFetcher.Contracts;

namespace WebPageFetcher
{
    public class WebPageFetcher
    {
        private readonly IWebClient _webClient;
        private readonly ILocalFileRepository _localFileRepository;
        private readonly IWebPageMetadataService _webPageMetadataService;
        private readonly ILogger _logger;

        public const string HtmlPageFileExtension = ".html";

        public WebPageFetcher(
            IWebClient webClient, 
            ILocalFileRepository localFileRepository, 
            IWebPageMetadataService webPageMetadataService, 
            ILoggerFactory loggerFactory)
        {
            _webClient = webClient;
            _localFileRepository = localFileRepository;
            _webPageMetadataService = webPageMetadataService;
            _logger = loggerFactory.CreateLogger<WebPageFetcher>();
        }

        public async Task FetchAndSave(IEnumerable<string> urls, bool printMetaData = false)
        {
            foreach (var url in urls)
            {
                try
                {
                    await FetchAndSave(url, printMetaData);
                }
                catch(HttpRequestException ex)
                {
                    _logger.LogError($"Request failed. Exception Message: {ex.Message}");
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"Request failed. Message: {ex.Message}");
                    throw;
                }
            }
        }

        private async Task FetchAndSave(string url, bool printMetaData = false)
        {
            var uri = new Uri(url);

            //Get web page
            Console.WriteLine($"Fetching webpage from URL: {url}");

            using (var webPageStream = await _webClient.GetWebPage(url))
            {
                //Print metadata
                if (printMetaData)
                {
                    PrintPageMetadata(webPageStream, url);
                }

                //Save web page
                var saveLocation = Environment.CurrentDirectory;
                var fileName = uri.Host + HtmlPageFileExtension;

                var filePath = Path.Combine(saveLocation, fileName);

                Console.WriteLine($"Saving webpage to webpage to file: {filePath}");
                await _localFileRepository.SaveFile(filePath, webPageStream);
            }
        }

        public void PrintPageMetadata(Stream webPageStream, string url)
        {
            var metadata = _webPageMetadataService.ParseMetaData(webPageStream, url);
            var consoleMessage = $"site: {metadata.Site}\nnum_links: {metadata.NumLinks}\nimages: {metadata.Images}\nlast_fetch: {metadata.LastFetch.ToUniversalTime().ToString("ddd MMM yyyy H:m UTC")}\n";

            Console.WriteLine(consoleMessage);
        }
    }
}
