using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.Scripts
{
    internal class Scraper
    {
        public HttpClient HttpClient { get; private set; }

        public Scraper() 
        {
            HttpClient = new HttpClient();
        }

        public void GetBooks()
        {

        }
    }
}
