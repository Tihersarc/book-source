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
                connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   // El while Read lee por cada fila de el resultado de la query
                    {
                        // Por cada linea de la query se crea el objeto Libro y se añade a la lista
                        Book book = new Book
                        {
                            IdBook = (int)reader["IdBook"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                        };
                        books.Add(book);
                    }
                }
                return books;
            }
            //return null;
        }


        public List<Book> GetTopTenBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Book> books = new List<Book>();

                string query = "SELECT TOP 10 * FROM Book ORDER BY Score DESC ;";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())   // El while Read lee por cada fila de el resultado de la query
                    {
                        // Por cada linea de la query se crea el objeto Libro y se añade a la lista
                        Book book = new Book
                        {
                            IdBook = (int)reader["IdBook"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                        };
                        books.Add(book);
                    }
                }
                return books;
            }
            //return null;
        }


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
                    if(reader.Read())
                    {
                        return new Book
                        {
                            IdBook = (int)reader["IdBook"],
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
                    return null;
                }
            }
        }

        public Book GetBookById(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM Book WHERE IdBook = @IdBook; ";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdBook", bookId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            IdBook = (int)reader["IdBook"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                        };
                    }
                }
            }
            return null;
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

        public List<Book> GetBooksByIdList(int ListBookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ListOfBooks_Book l INNER JOIN Book b " +
                    "ON l.FkIdBook = b.IdBook WHERE l.FkIdListOfBooks = @FkIdListOfBooks;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FkIdListOfBooks", ListBookId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Book> list = new List<Book>();

                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            IdBook = (int)reader["IdBook"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                            Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                            Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                            PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                            Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                        };
                        list.Add(book);
                    }
                    return list;
                }
            }
        }


        [Obsolete]
        public List<Book> GetBooksByCategory(string category)
        {
            List<Book> bookList = new List<Book>();
            string query = @$"
            SELECT *
            FROM Book
            INNER JOIN Book_Category
	            ON IdBook = FkIdBook
            INNER JOIN Category c
	            ON IdCategory = FkIdCategory
            WHERE c.CategoryName LIKE @category";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@category", category);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book
                                {
                                    IdBook = reader.GetInt32(reader.GetOrdinal("IdBook")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Author = reader.GetString(reader.GetOrdinal("Author")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                                    ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                                    Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                                    Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                                    PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                                    Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                                };
                                bookList.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR GetBooksByCategory.\n" + ex.ToString());
                throw;
            }

            return bookList;
        }

        [Obsolete] //-------------WIP--------------
        public List<Book> GetBooksByFilter(string? author = null, string? editorial = null, List<Category>? categoryList = null)
        {
            List<Book> bookList = new List<Book>();
            string query = @$"
            SELECT *
            FROM Book
            LEFT JOIN Book_Category book_cat
	            ON IdBook = FkIdBook
            LEFT JOIN Category cat
	            ON IdCategory = FkIdCategory
            WHERE 1 = 1 ";

            if (string.IsNullOrWhiteSpace(author))
                query += $"AND Author LIKE '@author'";

            if (string.IsNullOrWhiteSpace(editorial))
                query += $"AND Editorial LIKE '@editorial'";

            if (categoryList != null)
                query += $"AND CategoryName LIKE '@category'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        //cmd.Parameters.AddWithValue("@category", category);

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book
                                {
                                    IdBook = reader.GetInt32(reader.GetOrdinal("IdBook")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Author = reader.GetString(reader.GetOrdinal("Author")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                                    ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : (string)reader["ImageUrl"],
                                    Subtitle = reader.IsDBNull(reader.GetOrdinal("Subtitle")) ? null : (string)reader["Subtitle"],
                                    Editorial = reader.IsDBNull(reader.GetOrdinal("Editorial")) ? null : (string)reader["Editorial"],
                                    PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : (int)reader["PageCount"],
                                    Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? null : (double)reader["Score"]
                                };
                                bookList.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR GetBooksByCategory.\n" + ex.ToString());
                throw;
            }

            return bookList;
        }
    }
}
