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

        public UserViewModel(User user)
        {
            IdUser = user.IdUser;
            UserName = user.UserName;
            Birthdate = user.BirthDate;
            Email = user.Email;
            ProfileImageUrl = user.ProfileImageUrl;
        }
    }
}
