using BookSource.Models;
using System.Data;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class ListOfBooksDAL
    {
        private readonly IConfiguration _configuration;
        private string? connectionString;
        public ListOfBooksDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<ListOfBooks> GetListsOfByUserId(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ListOfBooks WHERE FkIdUser = @FkIdUser";
                SqlCommand cmd = new SqlCommand (query, conn);

                cmd.Parameters.AddWithValue("@FkIdUser", UserId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ListOfBooks> list = new List<ListOfBooks>();
                    while (reader.Read())
                    {
                        ListOfBooks listOfBooks = new ListOfBooks
                        {
                            IdListOfBooks = (int)reader["IdListOfBooks"],
                            ListName = (string)reader["ListName"],
                            RIdUser = (int)reader["FkIdUser"]
                        };
                        list.Add(listOfBooks);
                    }
                    return list;
                }
            }
        }



    }
}
