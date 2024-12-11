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
       public List<User>? FollowedList { get; set; }
       public List<User>? FollowerList { get; set; }

        public int? IdSelectedListOfBooks {  get; set; }

        public static UserViewModel UserMapper(User user)
        {
            return new UserViewModel
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                Birthdate = user.BirthDate,
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl
            };
        }
        public User MapperToUser()
        {
            return new User
            {
                IdUser = IdUser,
                UserName = UserName,
                BirthDate = Birthdate,
                Email = Email,
                ProfileImageUrl = ProfileImageUrl
            };
        }

    }
}
