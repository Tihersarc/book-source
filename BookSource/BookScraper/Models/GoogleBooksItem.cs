using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookScraper.Models
{
    public class GoogleBooksItem
    {

        [JsonPropertyName("id")]
        public string IdAPI { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo Volumeinfo { get; set; }
    }

    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; } = new List<string>();

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("publishedDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("pageCount")]
        public int? PageCount { get; set; }

        [JsonPropertyName("imageLinks")]
        public ImageLinks Imagelinks { get; set; }

        [JsonPropertyName("averageRating")]
        public float? AverageRating { get; set; }
    }

    public class ImageLinks
    {
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
