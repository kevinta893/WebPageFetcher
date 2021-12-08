using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebPageFetcher.Contracts;
using WebPageFetcher.Contracts.Models;

namespace WebPageParser.WebPageMetadataParser.Services
{
    public class WebPageMetadataParser : IWebPageMetadataService
    {
        public WebPageMetadataParser()
        {

        }

        public WebPageMetadataModel ParseMetaData(Stream pageStream, string url)
        {
            pageStream.Seek(0, SeekOrigin.Begin);
            var webDocument = new HtmlDocument();
            webDocument.Load(pageStream);

            // Count the number of links that are not empty
            var linkNodes = webDocument.DocumentNode.SelectNodes("//a[@href]");
            var numberOfLinks = linkNodes == null ? 0 : 
                linkNodes.Count(n => n != null && !string.IsNullOrEmpty(n.Attributes["href"]?.Value));

            // Count the number of images that are not empty
            var imageNodes = webDocument.DocumentNode.SelectNodes("//img[@src]");
            var numberOfImages = imageNodes == null ? 0 : 
                imageNodes.Count(n => !string.IsNullOrEmpty(n.Attributes["src"]?.Value));

            return new WebPageMetadataModel()
            {
                Site = url,
                NumLinks = numberOfLinks,
                Images = numberOfImages,
                LastFetch = DateTime.Now,       //probably clarify what is last fetch
            };
        }
    }
}
