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

        private readonly string endpointString = "https://www.googleapis.com/books/v1/volumes?";

        public Scraper() 
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri(endpointString);
            HttpClient.DefaultRequestHeaders.Accept.
        }

        public void GetBooks()
        {

        }
    }
}
