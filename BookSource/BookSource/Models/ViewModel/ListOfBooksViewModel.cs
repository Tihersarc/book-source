namespace BookSource.Models.ViewModel
{
    public class ListOfBooksViewModel
    {
        public required int IdListOfBooks { get; set; }
        public required string ListName { get; set; }
        public List<BookViewModel>? Books {  get; set; }
        public static List<ListOfBooksViewModel> MapperToViewModel(List<ListOfBooks> listsOfBooks)
        {
            List<ListOfBooksViewModel>mappedList = new List<ListOfBooksViewModel>();
            foreach (ListOfBooks listOfBook in listsOfBooks)
            {
                mappedList.Add(new ListOfBooksViewModel 
                { 
                    IdListOfBooks=listOfBook.IdListOfBooks,
                    ListName=listOfBook.ListName
                });
            }
            return mappedList;
        }
    }
}
