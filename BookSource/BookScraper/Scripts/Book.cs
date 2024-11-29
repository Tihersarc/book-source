using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.Scripts
{
    internal class Book
    {
        public string Title {  get; set; }
        public string Subtitle {  get; set; }
        public List<string> Genre { get; set; }
        public List<string> Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Description {  get; set; }
        public int PageCount {  get; set; }
        public string ImageLink {  get; set; }
    }
}
