using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace BookScraper.Models
{
    [Table(Name = "Book")]
    internal class Book
    {
        public string IdBook {  get; set; }
        public string IdAPI {  get; set; }
        public string Title {  get; set; }
        public string Subtitle {  get; set; }
        public string Genre { get; set; }
        public List<string> GenreList { get; set; } // Property to have each individual genre stored
        public string Author { get; set; }

        [Column(Name = "Editorial")]
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Description {  get; set; }
        public int PageCount {  get; set; }

        [Column(Name = "ImageUrl")]
        public string ImageLink {  get; set; }

        [Column(Name = "Score")]
        public float? AverageRating { get; set; }

        public override string ToString()
        {
            string authors = Author;
            string genres = GenreList != null && GenreList.Count > 0 ? string.Join(", ", Genre) : "No Genres";
            string subtitle = !string.IsNullOrWhiteSpace(Subtitle) ? $" - {Subtitle}" : string.Empty;
            string pageCount = PageCount.ToString();
            string releaseDate = !string.IsNullOrEmpty(ReleaseDate) ? ReleaseDate : "Unknown Release Date";
            string publisher = !string.IsNullOrEmpty(Publisher) ? Publisher : "Unknown Publisher";

            return $"Title: {Title}{subtitle}\n" +
                   $"Subtitle: {subtitle}\n" +
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
