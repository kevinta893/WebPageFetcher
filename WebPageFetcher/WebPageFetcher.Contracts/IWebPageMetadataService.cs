using System.IO;
using WebPageFetcher.Contracts.Models;

namespace WebPageFetcher.Contracts
{
    public interface IWebPageMetadataService
    {
        WebPageMetadataModel ParseMetaData(Stream pageStream, string url);
    }
}
