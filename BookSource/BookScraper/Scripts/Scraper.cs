using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpClient.DefaultRequestHeaders.Add("key", "placeholder");
        }

        public async Task<List<Book>> GetBooks(string query, int page = 0, int pageSize = 40)
        {
            List<GoogleBooksItem> itemList = new List<GoogleBooksItem>();
            List<Book> bookList = new List<Book>();

            try
            {
                int startIndex = page * pageSize;
                string request = $"{endpointString}?q={query}&startIndex={startIndex}&maxResults={pageSize}";

                HttpResponseMessage response = await HttpClient.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    JsonElement jsonObject = JsonSerializer.Deserialize<JsonElement>(responseString);


                    if (jsonObject.TryGetProperty("items", out JsonElement element) && element.ValueKind == JsonValueKind.Array)
                    {
                        itemList = JsonSerializer.Deserialize<List<GoogleBooksItem>>(element.ToString());

                        foreach (var item in itemList)
                        {
                            bookList.Add(ItemToBook(item));
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error: " + response.StatusCode);
                }

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
                //Build request and sending it to the API
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

        public Book ItemToBook(GoogleBooksItem item)
        {
            Book book = new Book();

            try
            {
                book = new Book
                {
                    IdAPI = item.IdAPI,
                    Title = item.Volumeinfo?.Title,
                    Subtitle = item.Volumeinfo?.Subtitle,

                    Author = item.Volumeinfo?.Authors.Count > 0 ? 
                        string.Join(", ", item.Volumeinfo?.Authors) : "Unknown Author",
                    Genre = item.Volumeinfo?.Categories.Count > 0 ? 
                        string.Join(", ", item.Volumeinfo?.Categories) : "No Genres",
                    GenreList = item.Volumeinfo?.Categories,

                    Publisher = item.Volumeinfo?.Publisher,
                    ReleaseDate = item.Volumeinfo?.ReleaseDate,
                    Description = item.Volumeinfo?.Description,
                    PageCount = item.Volumeinfo.PageCount.ToString(),
                    ImageLink = item.Volumeinfo?.Imagelinks?.Thumbnail
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in ItemToBook:\n" + ex);
            }

            return book;
        }

        public GoogleBooksItem JsonToItem(string json)
        {
            GoogleBooksItem item;

            try
            {
                item = JsonSerializer.Deserialize<GoogleBooksItem>(json);

                //book = ItemToBook(item);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.ToString());
                throw;
            }

            return item;
        }

        public Book JsonToBook(string json)
        {
            // First gets the json and parses it to a GoogleBooksItem,
            // then parses the GoogleBooksItem to a book
            Book book = ItemToBook(JsonToItem(json));

            return book;
        }
    }
}
