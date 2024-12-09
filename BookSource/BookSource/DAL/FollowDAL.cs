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

        public List<int> GetFollowerList(int userId)
        {
            List<int> followerList = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT FkIdFollower " +
                        "FROM Follow " +
                        "WHERE FkIdFollowed = @FkIdFollowed;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FkIdFollowed", userId);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                followerList.Add(reader.GetInt32(reader.GetOrdinal("FkIdFollower")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Inserting Follower: " + ex.ToString());
            }

            return followerList;
        }

        public List<int> GetFollowedList(int userId)
        {
            List<int> followedList = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT FkIdFollowed " +
                        "FROM Follow " +
                        "WHERE FkIdFollower = @FkIdFollower;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FkIdFollower", userId);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                followedList.Add(reader.GetInt32(reader.GetOrdinal("FkIdFollowed")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Inserting Followed: " + ex.ToString());
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
