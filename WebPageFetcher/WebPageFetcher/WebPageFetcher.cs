using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebPageFetcher.Contracts;

namespace WebPageFetcher
{
    public class WebPageFetcher
    {
        private readonly IWebClient _webClient;
        private readonly ILocalFileRepository _localFileRepository;
        private readonly ILogger _logger;

        public const string HtmlPageFileExtension = ".html";

        public WebPageFetcher(IWebClient webClient, ILocalFileRepository localFileRepository, ILoggerFactory loggerFactory)
        {
            _webClient = webClient;
            _localFileRepository = localFileRepository;
            _logger = loggerFactory.CreateLogger<WebPageFetcher>();
        }

        public async Task FetchAndSave(IEnumerable<string> urls, bool printMetaData = false)
        {
            foreach (var url in urls)
            {
                await FetchAndSave(url, printMetaData);
            }
        }

        public async Task FetchAndSave(string url, bool printMetaData = false)
        {
            var uri = new Uri(url);

            //Get web page
            _logger.LogInformation($"Fetching webpage from URL: {url}");
            var webPageStream = await _webClient.GetWebPage(url);

            //Save web page
            var saveLocation = Environment.CurrentDirectory;
            var fileName = uri.Host + HtmlPageFileExtension;

            var filePath = Path.Combine(saveLocation, fileName);

            _logger.LogInformation($"Saving webpage to webpage to file: {filePath}");
            await _localFileRepository.SaveFile(filePath, webPageStream);
        }
    }
}
