namespace BookSource.Models.ViewModel
{
    public class UserViewModel
    {
       public required int  IdUser { get; set; }
       public required string UserName { get; set; }
       public DateTime? Birthdate { get; set; }
       public required string Email { get; set; }
       public string? ProfileImageUrl { get; set; }
       public List<ListOfBooksViewModel>? ListOfBooks { get; set; }
       public int? IdSelectedListOfBooks {  get; set; }
    }
}
