namespace BookSource.Models.ViewModel
{
    public class BookViewModel
    {
        public required int IdBook { get; set; }
        public required string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? ImageLink { get; set; }
        public string? Description { get; set; }
        public required string Editorial { get; set; }
        public required int PageCount { get; set; }
        public required double Score { get; set; }
        public required string Author { get; set; }
        public required List<CategoryViewModel> Categories { get; set; }    
    }
}
