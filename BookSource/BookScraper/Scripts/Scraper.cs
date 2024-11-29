using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookScraper.Scripts
{
    internal class Scraper
    {
        public HttpClient HttpClient { get; private set; }

        private readonly string uriString = "https://www.googleapis.com/";
        private readonly string endpointString = "books/v1/volumes";

        public Scraper() 
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri(uriString);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/jason"));
            //HttpClient.DefaultRequestHeaders.Add("key", "placeholder");
        }

        public Task<List<Book>> GetBooks(string query,int page = 0, int pageSize = 40)
        {
            List<Book> bookList = new List<Book>();

            try
            {
                int startIndex = page * pageSize;
                string request = $"{endpointString}?q={query}&startIndex={startIndex}&maxResults={pageSize}";
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Test" + ex.ToString());
            }

            return bookList;
        }

        public async Task<Book> GetBookById(string id)
        {
            Book book = null;

            try
            {
                string request = uriString + endpointString + "/" + id;

                HttpResponseMessage response = await HttpClient.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    book = JsonToBook(responseString);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error: " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
                
            return book;
        }

        public Book JsonToBook(string json)
        {
            Book book = JsonSerializer.Deserialize<Book>(json);

            return book;
        }
    }
}
