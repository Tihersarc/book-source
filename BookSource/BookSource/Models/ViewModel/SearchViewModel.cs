using System.Xml;

namespace BookSource.Models.ViewModel
{
    public class SearchViewModel
    {
        public string? Title { get; set; }
        public string? OrderType { get; set; }

        public string? Category { get; set; }
        public BookListViewModel BookListViewModel {get; set;}

        // En caso de que no se le pase nada se inicializa
        public SearchViewModel()
        {
            BookListViewModel = new BookListViewModel();
        }
    }
}
