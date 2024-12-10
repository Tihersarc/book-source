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

        public ListOfBooks GetListOfBooksById(int ListOfBookId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ListOfBooks WHERE IdListOfBooks = @IdListOfBooks;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdListOfBooks", ListOfBookId);
                conn.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ListOfBooks
                        {
                            IdListOfBooks = (int)reader["IdListOfBooks"],
                            ListName = (string)reader["ListName"],
                            RIdUser = (int)reader["FkIdUser"]
                        };
                    }
                    return null;
                }
            }
        }

        public bool CreateListOfBooks(ListOfBooks listOfBooks)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ListOfBooks(ListName, FkIdUser)" +
                    "VALUES(@ListName, @FkIdUser)";
                SqlCommand cmd = new SqlCommand (query, conn);

                cmd.Parameters.AddWithValue("@ListName", listOfBooks.ListName); 
                cmd.Parameters.AddWithValue("@FkIdUser", listOfBooks.RIdUser);
                conn.Open();

                int affectedRows = 0;

                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    return true;

                return false;
            }
        }

        // Tiene OnDeleteCascade de manera que si eliminamos una lista, tambien se eliminan los registros de
        // libros de esa lista
        public bool RemoveListOfBooks(ListOfBooks listOfBooks)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ListOfBooks WHERE IdListOfBooks = @IdListOfBooks";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdListOfBooks", listOfBooks.IdListOfBooks);
                conn.Open();

                int affectedRows = 0;

                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    return true;

                return false;
            }
        }

        // No modificar el Id, sino no funcionará
        public ListOfBooks UpdateListOfBooks(ListOfBooks listOfBooks)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListOfBooks SET ListName = @ListName," +
                    "WHERE IdListOfBooks = @IdListOfBooks;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdListOfBooks", listOfBooks.IdListOfBooks);
                cmd.Parameters.AddWithValue("@ListName", listOfBooks.ListName);
                conn.Open();

                int affectedRows = 0;
                affectedRows =  cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return listOfBooks;
                }
                return null;
            }

        }

        public ListOfBooks AddBookToListBook(ListOfBooks listOfBooks, Book book)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ListOfBooks_Book(FkIdListOfBooks, FkIdBook) " +
                    "VALUES(@FkIdListOfBooks, @FkIdBook)";
                SqlCommand cmd = new SqlCommand(query,conn);

                cmd.Parameters.AddWithValue("@FkIdListOfBooks", listOfBooks.IdListOfBooks);
                cmd.Parameters.AddWithValue("@FkIdBook", book.IdBook);
                conn.Open();

                int affectedRows = 0;
                affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return listOfBooks;
                }
                return null;

            }
        }

    }
}
