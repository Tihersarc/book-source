
using System.Data.Linq.Mapping;

namespace BookScraper.Models
{
    [Table(Name = "Book_Category")]
    internal class Book_Category
    {
        public int FkIdCategory { get; set; }
        public int FkIdBook { get; set; }
    }
}
