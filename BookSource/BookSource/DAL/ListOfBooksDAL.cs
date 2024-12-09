using BookSource.Models;
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

        //public List<ListOfBooks> GetListsOfByUsername(string UserName)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM ListOfBooks WHERE ";
            

        //    }

        //}

    }
}
