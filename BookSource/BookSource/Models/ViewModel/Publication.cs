namespace BookSource.Models.ViewModel
{
    public class Publication
    {
        public int IdPublication { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? PubImage { get; set; }
        public required int IdUser { get; set; }
        public int? Likes { get; set; }
    }
}
