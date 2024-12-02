using BookSource.Models;
namespace BookSource.DAL
{
    public class UserDAL
    {

        private readonly IConfiguration _configuration;
        public UserDAL(IConfiguration configuration)
        {
           _configuration = configuration;
           var connectionString = _configuration.GetConnectionString("DefaultConnection");

        }

        public User getUsuarioLogin(string username, string password)
        {
            return null;
        }
    }
}
