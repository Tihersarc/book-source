namespace BookSource.Models.ViewModel
{
    public class ListOfBooksViewModel
    {
        public required int IdListOfBooks { get; set; }
        public required string ListName { get; set; }
        public List<BookViewModel>? Books {  get; set; }
    }
}
