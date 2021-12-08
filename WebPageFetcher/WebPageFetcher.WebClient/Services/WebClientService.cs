using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebPageFetcher.Contracts;

namespace WebPageFetcher.WebClient.Services
{
    /// <summary>
    /// A web client that gets a webpage
    /// </summary>
    public class WebClientService : IWebClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public WebClientService(HttpClient httpClient, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<WebClientService>();
        }

        public async Task<Stream> GetWebPage(string url)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            try
            {
                var response = await _httpClient.SendAsync(request);
                return await response.Content.ReadAsStreamAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Http Request failed.");
                throw;
            }
        }
    }
}
