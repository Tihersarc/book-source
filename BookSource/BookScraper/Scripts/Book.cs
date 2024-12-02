using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.Scripts
{
    internal class Book
    {
        public string IdAPI {  get; set; }
        public string Title {  get; set; }
        public string Subtitle {  get; set; }
        public string Genre { get; set; }
        public List<string> GenreList { get; set; } // Property to have each individual genre stored
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Description {  get; set; }
        public string PageCount {  get; set; }
        public string ImageLink {  get; set; }


        public override string ToString()
        {
            string authors = Author;
            string genres = GenreList != null && GenreList.Count > 0 ? string.Join(", ", Genre) : "No Genres";
            string subtitle = !string.IsNullOrWhiteSpace(Subtitle) ? $" - {Subtitle}" : string.Empty;
            string pageCount = !string.IsNullOrWhiteSpace(PageCount) ? PageCount : "N/A";
            string releaseDate = !string.IsNullOrEmpty(ReleaseDate) ? ReleaseDate : "Unknown Release Date";
            string publisher = !string.IsNullOrEmpty(Publisher) ? Publisher : "Unknown Publisher";

            return $"Title: {Title}{subtitle}\n" +
                   $"Subtitle: {Subtitle}\n" +
                   $"Genre(s): {genres}\n" +
                   $"Author(s): {authors}\n" +
                   $"Publisher: {publisher}\n" +
                   $"Release Date: {releaseDate}\n" +
                   $"Description: {Description}" +
                   $"Page Count: {pageCount}\n" +
                   $"Image Link: {ImageLink}\n";
        }
    }
}
