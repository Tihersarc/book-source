using System.Collections.Generic;

namespace BookScraper.Scripts
{
    public class GoogleBooksItem
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<string> Authors { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Thumbnail { get; set; }
    }
}
