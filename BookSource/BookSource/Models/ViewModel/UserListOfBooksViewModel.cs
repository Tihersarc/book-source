namespace BookSource.Models.ViewModel
{
    public class UserListOfBooksViewModel
    {
        public required string UserName { get; set; }
        public int? IdSelectedList { get; set; }

        public List<ListOfBooksViewModel> UserListOfBooks{get;set;}
    }
}
