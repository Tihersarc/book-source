namespace BookSource.Models
{
    public class User
    {
        public required int IdUser { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }

    }
}
