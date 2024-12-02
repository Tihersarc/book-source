namespace BookSource.Models
{
    public class Book
    {
        public int IdBook { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Description { get; set; }
        public string? ImageLink { get; set; }
        public string? ImageUrl { get; set; }
        public string? Subtitle { get; set; }
        public string? Editorial { get; set; }
        public int? PageCount { get; set; }
        public double? Score { get; set; }

    }
}
