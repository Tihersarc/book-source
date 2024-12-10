namespace BookSource.Models.ViewModel.TestViewModel
{
    public class TestViewModel
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Book { get; set; }

        //public List<ListOfBooks>? ListsOfBooks { get; set; }
        public List<Book>? Books { get; set; }
        public ListOfBooks? ListOfBooks { get; set; }
    }
}
