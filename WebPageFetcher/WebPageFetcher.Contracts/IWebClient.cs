using System;
using System.IO;
using System.Threading.Tasks;

namespace WebPageFetcher.Contracts
{
    /// <summary>
    /// A web client that fetches pages
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Performs a GET against the given url
        /// Returns a data stream
        /// </summary>
        /// <param name="url">The URL to send the request to</param>
        /// <returns></returns>
        Task<Stream> GetWebPage(string url);
    }
}
