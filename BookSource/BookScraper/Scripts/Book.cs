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

        public override string ToString()
        {
            string authors = Author != null && Author.Count > 0 ? string.Join(", ", Author) : "Unknown Author";
            string genres = Genre != null && Genre.Count > 0 ? string.Join(", ", Genre) : "No Genres";
            string subtitle = !string.IsNullOrEmpty(Subtitle) ? $" - {Subtitle}" : string.Empty;
            string pageCount = PageCount > 0 ? PageCount.ToString() : "N/A";
            string releaseDate = !string.IsNullOrEmpty(ReleaseDate) ? ReleaseDate : "Unknown Release Date";
            string publisher = !string.IsNullOrEmpty(Publisher) ? Publisher : "Unknown Publisher";

            return $"Title: {Title}{subtitle}\n" +
                   $"Author(s): {authors}\n" +
                   $"Genre(s): {genres}\n" +
                   $"Publisher: {publisher}\n" +
                   $"Release Date: {releaseDate}\n" +
                   $"Page Count: {pageCount}\n" +
                   $"Description: {Description}";
        }
    }
}
