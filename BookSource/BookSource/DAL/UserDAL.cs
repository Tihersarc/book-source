using BookSource.Models;
using BookSource.Tools;
using Microsoft;
using System.Data;
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User] WHERE UserName = @UserName;";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Get the Hash and Salt values and verify the password
                        var passwordHash = (byte[])reader["PasswordHash"];
                        var passwordSalt = (byte[])reader["PasswordSalt"];

                        if (PasswordHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
                        {
                            // If the password is OK, return the full user info
                            return new User
                            {
                                IdUser = (int)reader["IdUser"],
                                UserName = (string)reader["UserName"],
                                Email = (string)reader["Email"],
                                PasswordHash = passwordHash,
                                PasswordSalt = passwordSalt,
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                                ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        [Obsolete]
        public bool CreateUser(User user, string password)
        {
            PasswordHelper.CreatePasswordHash(password, out byte[] PasswordHash, out byte[] PasswordSalt);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO User(UserName, Email, PasswordHash, PasswordSalt, BirthDate, ProfileImageUrl)
                                VALUES (@UserName, @Email, @PasswordHash, @PasswordHash, @BirthDate, @ProfileImageUrl)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);
                cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate == null ? DBNull.Value : user.BirthDate);
                cmd.Parameters.AddWithValue("@ProfileImageUrl", user.ProfileImageUrl == null ? DBNull.Value : user.ProfileImageUrl);

                int affectedRows = 0;

                connection.Open();
                try
                {
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    {
                        Console.WriteLine("Error al Crear el usuario: " + ex.Message);
                    }

                    if (affectedRows > 0)
                        return true;
                }
                return false;
            }
        }
    }
}
