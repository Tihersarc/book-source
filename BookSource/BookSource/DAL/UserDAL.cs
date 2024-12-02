using BookSource.Models;
using Microsoft;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class UserDAL
    {

        private readonly IConfiguration _configuration;
        private string connectionString;
        public UserDAL(IConfiguration configuration)
        {
           _configuration = configuration;
           connectionString = _configuration.GetConnectionString("DefaultConnection");

        }

        [Obsolete]
        public User GetUsuarioLogin(string username, string password)
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User] WHERE UserName = @UserName;";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // If there is a User found, we have to get the paswords
                        // and verify if the salt hash + password is right
                    }
                }
            }

            return null;
        }
    }
}
