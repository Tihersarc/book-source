namespace BookSource.Models
{

    /*
     * Modelo Usuario
     *      De momento usuario no tiene como required IdUser y Passwords ya que en la gestion de Auth
     *       se generan objetos usuario que aun no requieren estos campos, pero tampoco son ?
     */
    public class User
    {
        public int IdUser { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }

    }
}
