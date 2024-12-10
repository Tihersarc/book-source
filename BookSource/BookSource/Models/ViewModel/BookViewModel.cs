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
        public required List<CategoryViewModel> Categories { get; set; }
        public static BookViewModel BookMapper(Book book)
        {
            return new BookViewModel
            {
                IdBook = book.IdBook,
                Title = book.Title,
                SubTitle = book.Subtitle, // Map Subtitle to SubTitle
                ImageLink = book.ImageUrl, // Map ImageUrl to ImageLink
                Description = book.Description,
                Editorial = book.Editorial,
                PageCount = book.PageCount,
                Score = book.Score,
                Author = book.Author,
                Categories = new List<CategoryViewModel>()
            };
        }
        public static List<BookViewModel> ListBookMapper(IEnumerable<Book>ListBooks)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            foreach (Book book in ListBooks)
                books.Add(BookMapper(book));
            return books;
        }
    }
}
