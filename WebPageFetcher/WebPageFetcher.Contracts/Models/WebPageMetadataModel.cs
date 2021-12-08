using System;

namespace WebPageFetcher.Contracts.Models
{
    public class WebPageMetadataModel
    {
        public string Site { get; set; }
        public int NumLinks { get; set; }
        public int Images { get; set; }
        public DateTime LastFetch { get; set; }
    }
}
