using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class FollowDAL
    {
        string connectionString;
        public FollowDAL() {
            //ToDo
        }

        public void AddFollower(int followerId, int followedId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = 
                    "INSERT INTO Follow (FkIdFollower, FkIdFollowed)" +
                    "VALUES (@FkIdFollower, @FkIdFollowed)";

                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@FkIdFollower", followerId);
                cmd.Parameters.AddWithValue("@FkIdFollowed", followedId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Inserting Follower: " + ex.ToString());
                }
            }
        }

        public List<int> GetFollowerList(int userId)
        {
            List<int> followerList = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = 
                    "SELECT FkIdFollower" +
                    "FROM Follow" +
                    "WHERE FkIdFollowed = @FkIdFollowed";

                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@FkIdFollowed", userId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            followerList.Add(reader.GetInt32(reader.GetOrdinal("FkIdFollower")));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Inserting Follower: " + ex.ToString());
                }
            }

            return followerList;
        }
    }
}
