using BookSource.Models;
using System.Data.SqlClient;
using System.Net;

namespace BookSource.DAL
{
    public class CategoriesDAL
    {
        private readonly IConfiguration _configuration;
        private string? connectionString;
        public CategoriesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Category> GetCategoryByBookId(int BookId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Book_Category b INNER JOIN Category c " +
                    "ON b.FkIdCategory = c.IdCategory WHERE b.FkIdBook = @FkIdBook;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FkIdBook", BookId);
                conn.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Category> categories = new List<Category>();
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = (int)reader["IdCategory"],
                            CategoryName = (string)reader["CategoryName"]
                        };
                        categories.Add(category);
                    }
                    return categories;
                }

            }
        }

        public List<Category> GetAllCategories() 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Category;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Category> categories = new List<Category>();
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = (int)reader["IdCategory"],
                            CategoryName = (string)reader["CategoryName"]
                        };
                        categories.Add(category);
                    }
                    return categories;
                }

            }
        }

    }
}
