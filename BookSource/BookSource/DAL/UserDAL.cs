using BookSource.Models;
using BookSource.Tools;
using Microsoft;
using Microsoft.AspNetCore.Identity;
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

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Get the Hash and Salt values and verify the password
                        var passwordHash = (byte[])reader["PasswordHash"];
                        var passwordSalt = (byte[])reader["PasswordSalt"];

                        bool a = PasswordHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
                        if (PasswordHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
                        {
                            // If the password is OK, return the full newUser info
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
                string query = "INSERT INTO [User](UserName, Email, PasswordHash, PasswordSalt, BirthDate, ProfileImageUrl)"
                             + "VALUES (@UserName, @Email, @PasswordHash, @PasswordSalt, @BirthDate, @ProfileImageUrl);";

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
                     Console.WriteLine("Error al Crear el usuario: " + ex.Message);
                }
                if (affectedRows > 0)
                    return true;
                return false;
            }
        }

        [Obsolete]
        public User GetUserByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User] WHERE UserName = @UserName;";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@UserName", userName);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User()
                        {
                            IdUser = (int)reader["IdUser"],
                            UserName = (string)reader["UserName"],
                            Email = (string)reader["Email"],
                            PasswordHash = (byte[])reader["PasswordHash"],  // No estoy seguro si se deberia dar esta info ya que se podria obtener de cualquier usuario....
                            PasswordSalt = (byte[])reader["PasswordSalt"],
                            BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                            ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                        };
                    }
                }
            }
            return null;
        }
        public User GetUserById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User] WHERE IdUser = @IdUser;";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@IsUser", Id);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User()
                        {
                            IdUser = (int)reader["IdUser"],
                            UserName = (string)reader["UserName"],
                            Email = (string)reader["Email"],
                            PasswordHash = (byte[])reader["PasswordHash"],  // No estoy seguro si se deberia dar esta info ya que se podria obtener de cualquier usuario....
                            PasswordSalt = (byte[])reader["PasswordSalt"],
                            BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                            ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                        };
                    }
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User]";
                SqlCommand cmd = new SqlCommand(query, connection);
                List<User> users = new List<User>();

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            IdUser = (int)reader["IdUser"],
                            UserName = (string)reader["UserName"],
                            Email = (string)reader["Email"],
                            PasswordHash = (byte[])reader["PasswordHash"],  // No estoy seguro si se deberia dar esta info ya que se podria obtener de cualquier usuario....
                            PasswordSalt = (byte[])reader["PasswordSalt"],
                            BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                            ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                        });
                    }
                    return users;
                }
            }
        }


        // No modificar el IdUser, sino no funcionará
        [Obsolete]
        public User UpdateUser(User user)
        {
            byte[] PasswordHash = null;
            byte[] PasswordSalt = null;

            if (user.Password != null && user.Password != "")
            {
                PasswordHelper.CreatePasswordHash(user.Password, out  PasswordHash, out PasswordSalt);
            }
            if (PasswordSalt != null && PasswordHash != null)
            {
                user.PasswordSalt = PasswordSalt;
                user.PasswordHash = PasswordHash;
            }
            try
            {
                string query;
                if (user.PasswordSalt != null && user.PasswordHash != null)
                {
                    query = "UPDATE [User] SET BirthDate = @BirthDate, "
                        + "ProfileImageUrl = @ProfileImageUrl,"
                        + "PasswordHash = @PasswordHash,"
                        + "PasswordSalt = @PasswordSalt "
                        + "WHERE IdUser = @IdUser";
                }
                else
                {
                    query = "UPDATE [User] SET BirthDate = @BirthDate, " 
                        + "ProfileImageUrl = @ProfileImageUrl " 
                        + "WHERE IdUser = @IdUser";
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdUser", user.IdUser);
                        cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate == null ? DBNull.Value : user.BirthDate);
                        cmd.Parameters.AddWithValue("@ProfileImageUrl", user.ProfileImageUrl);
                        if (user.PasswordSalt != null && user.PasswordHash != null)
                        {
                            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                            cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                        }
                        connection.Open();
                        int affectedRows = 0;

                        affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            return user;
                        }
                        else
                        {
                            return null;
                        }

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on newUser UPDATE:\n" + ex.ToString());
                throw;
            }

            return user;
        }
    }
}
