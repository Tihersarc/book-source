using BookSource.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class ReviewDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public ReviewDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public List<Review> GetReviewsByIdBook(int idBook)
        {
            var reviews = new List<Review>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT IdReview, Comment, FKIdBook, FKIdUser FROM Review" +
                    " WHERE FKIdBook = @idBook";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idBook", idBook);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var review = new Review
                            {
                                IdReview = reader.GetInt32(reader.GetOrdinal("IdReview")),
                                Comment = reader.GetString(reader.GetOrdinal("Comment")),
                                RIdBook = reader.GetInt32(reader.GetOrdinal("FKIdBook")),
                                RIdUser = reader.GetInt32(reader.GetOrdinal("FKIdUser"))
                            };

                            reviews.Add(review);
                        }
                    }
                }
            }

            return reviews;

        }
        public Review GetReviewById(int idReview)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Review WHERE IdReview = @IdReview; ";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@IdReview", idReview);


                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Review
                        {
                            IdReview = (int)reader["IdReview"],
                            Comment = (string)reader["Comment"],
                            RIdBook = (int)reader["FkIdBook"],
                            RIdUser = (int)reader["FkIdUser"]
                        };
                    }
                    return null;
                }

            }
        }
        public Review CreateReview(Review review)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Review(Comment, FkIdBook, FkIdUser) " +
                        "VALUES(@Comment, @FkIdBook, @FkIdUser) " +
                        "SELECT SCOPE_IDENTITY();";


                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Comment", review.Comment);
                cmd.Parameters.AddWithValue("@FkIdBook", review.RIdBook);
                cmd.Parameters.AddWithValue("@FkIdUser", review.RIdUser);

                connection.Open();
                int idReview;
                idReview = Convert.ToInt32(cmd.ExecuteScalar());
                return GetReviewById(idReview);
            }
        }
    }
}
