using BookSource.Models;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class FollowDAL
    {
        private IConfiguration _configuration;
        string connectionString;
        public FollowDAL(IConfiguration configuration) {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void AddFollower(int followerId, int followedId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = 
                        "INSERT INTO Follow (FkIdFollower, FkIdFollowed) " +
                        "VALUES (@FkIdFollower, @FkIdFollowed);";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FkIdFollower", followerId);
                        cmd.Parameters.AddWithValue("@FkIdFollowed", followedId);

                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Inserting Follower: " + ex.ToString());
            }
        }

        public List<User> GetFollowerList(int userId)
        {
            List<User> followerList = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Follow f "
                        + "INNER JOIN[User] u ON f.FkIdFollower = u.IdUser "
                        + "WHERE FkIdFollowed = @FkIdFollowed; ";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FkIdFollowed", userId);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    IdUser = (int)reader["IdUser"],
                                    UserName = (string)reader["UserName"],
                                    Email = (string)reader["Email"],
                                    BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                                    ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                                };
                                followerList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting Follower: " + ex.ToString());
            }

            return followerList;
        }


        public List<User> GetFollowedList(int userId)
        {
            List<User> followedList = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Follow f "
                        + "INNER JOIN[User] u ON f.FkIdFollowed = u.IdUser "
                        + "WHERE FkIdFollower = @FkIdFollower; ";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FkIdFollower", userId);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    IdUser = (int)reader["IdUser"],
                                    UserName = (string)reader["UserName"],
                                    Email = (string)reader["Email"],
                                    BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : (DateTime?)reader["BirthDate"],
                                    ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("ProfileImageUrl")) ? null : (string?)reader["ProfileImageUrl"]
                                };
                                followedList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting Followed: " + ex.ToString());
            }

            return followedList;
        }

        public bool DeleteFollow(int followerId, int followedId)
        {
            int affectedRows = 0;

            string query =
                "DELETE FROM Follow " +
                "WHERE " +
                "   FkIdFollowed = @followedId AND " +
                "   FkIdFollower = @followerId;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@followerId", followerId);
                        cmd.Parameters.AddWithValue("@followedId", followedId);

                        connection.Open();
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on DELETE Follow" + ex.ToString());
                throw;
            }

            //Returns true if there's any row affected
            return affectedRows > 0;
        }
    }
}
