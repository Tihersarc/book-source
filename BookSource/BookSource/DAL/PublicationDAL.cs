using BookSource.Models;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class PublicationDAL
    {

        private readonly IConfiguration _configuration;
        private string connectionString;
        public PublicationDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Publication> GetAllPublications()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Publication";
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Publication> publications = new List<Publication>();

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        publications.Add(new Publication()
                        {
                            IdPublication = (int)reader["IdPublication"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                            PubImage = reader.IsDBNull(reader.GetOrdinal("PubImage")) ? null : (string?)reader["PubImage"],
                            RIdUser = (int)reader["FkIdUser"]
                        });
                    }
                    return publications;
                }
            }
        }
    }
}
