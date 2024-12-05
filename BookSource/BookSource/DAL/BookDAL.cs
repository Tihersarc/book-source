using BookSource.Models;
using System.Data.SqlClient;

namespace BookSource.DAL
{
    public class BookDAL
    {
        private readonly IConfiguration _configuration;
        private string? connectionString;
        public BookDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Book> GetAllBooks()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Book> books = new List<Book>();

                string query = "SELECT * FROM Book;";

                SqlCommand cmd = new SqlCommand(query, connection);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   // El while Read lee por cada fila de el resultado de la query
                    {
                        // Por cada linea de la query se crea el objeto Libro y se añade a la lista
                        Book book = new Book
                        {
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (float)reader["Score"]
                        };
                        books.Add(book);
                    }
                }
                return books;
            }
            //return null;
        }

        // Se podria hacer un getBy generico 
        public Book GetBookByTitle(string bookTitle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM Book WHERE Title = @Title; ";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", bookTitle);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    {
                        return new Book
                        {
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (float)reader["Score"]
                        };
                    }
                }
            }
        }

        public bool CreateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO Book(Title, Author, Description, ImageUrl, Subtitle, Editorial, PageCount, Score) "
                              + "VALUES (@Title, @Author, @Description, @ImageUrl, @Subtitle, @Editorial, @PageCount, @Score)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Description", book.Description);
                cmd.Parameters.AddWithValue("@ImageUrl", book.ImageUrl);
                cmd.Parameters.AddWithValue("@Subtitle", book.Subtitle);
                cmd.Parameters.AddWithValue("@Editorial", book.Editorial);
                cmd.Parameters.AddWithValue("@PageCount", book.PageCount);
                cmd.Parameters.AddWithValue("@Score", book.Score);

                int affectedRows;
                connection.Open();
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
