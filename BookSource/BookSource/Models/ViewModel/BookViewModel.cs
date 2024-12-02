namespace BookSource.Models.ViewModel
{
    public class BookViewModel
    {
        public required int IdBook { get; set; }
        public required string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? ImageLink { get; set; }
        public string? Description { get; set; }
        public string? Editorial { get; set; }
        public int? PageCount { get; set; }
        public double? Score { get; set; }
        public string? Author { get; set; }
        public required List<CategoryViewModel>? Categories { get; set; }    
    }
}
